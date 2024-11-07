using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PodcastAPI.Data;
using PodcastAPI.Models;

namespace PodcastAPI.Endpoints;

public static class ShowdownEndpoints
{
    public static void MapShowdownEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("").WithTags(nameof(ShowdownResult));

        group.MapPost("/showdown", (PodcastAPIDbContext db, ShowdownResult showdownResult) =>
        {
            if (showdownResult.WinningPodcastId == showdownResult.LosingPodcastId)
            {
                return Results.BadRequest("Winning Podcast Id and Losing Podcast Id cannot be the same.");
            }

            var winningPodcast = db.Podcasts.SingleOrDefault(p => p.Id == showdownResult.WinningPodcastId);

            if (winningPodcast == null)
            {
                return Results.NotFound("Winning podcast id is not found!");
            }

            var losingPodcast = db.Podcasts.SingleOrDefault(p => p.Id == showdownResult.LosingPodcastId);

            if (losingPodcast == null)
            {
                return Results.NotFound("Losing podcast id is not found!");
            }

            if (!db.Users.Any(u => u.Id == showdownResult.UserId))
            {
                return Results.NotFound("UserId is not found!");
            }

            var matchingResults = db.ShowdownResults
                                        .Where(sr => sr.UserId == showdownResult.UserId)
                                        .Where(sr => sr.WinningPodcastId == showdownResult.WinningPodcastId || sr.WinningPodcastId == showdownResult.LosingPodcastId)
                                        .Where(sr => sr.LosingPodcastId == showdownResult.WinningPodcastId || sr.LosingPodcastId == showdownResult.LosingPodcastId)
                                        .SingleOrDefault();

            if (matchingResults != null)
            {
                return Results.BadRequest("The user has already rated these Podcasts");
            }

            ShowdownResult newShowdownResult = new ShowdownResult
            {
                WinningPodcastId = showdownResult.WinningPodcastId,
                LosingPodcastId = showdownResult.LosingPodcastId,
                UserId = showdownResult.UserId,
                GenreId = winningPodcast.GenreId == losingPodcast.GenreId ? winningPodcast.GenreId : -1
            };

            db.ShowdownResults.Add(newShowdownResult);
            db.SaveChanges();
            return Results.Created();
        });

        group.MapGet("/podcasts/showdown/{genreId}", (PodcastAPIDbContext db, int genreId, int userId) =>
        {
            if (!db.Genres.Any(g => g.Id == genreId))
            {
                return Results.NotFound("Genre id is not valid!");
            }

            if (!db.Users.Any(u => u.Id == userId))
            {
                return Results.NotFound("UserId is not valid!");
            }

            List<int> totalPodcasts = db.Podcasts.Where(p => p.GenreId == genreId).Select(p => p.Id).ToList();


            if (totalPodcasts.Count < 2)
            {
                return Results.Ok("There are not enough podcasts in this genre.");
            }

            List<ShowdownResult> showdownResults = db.ShowdownResults
                       .Where(sr => sr.UserId == userId && sr.GenreId == genreId)
                       .ToList();

            int num = 1;

            // this k!
            int denom = 2;

            //Combination formula: n! / (k! * (n - k)!)

            // int = 2 so we avoid the n returning itself by multiply by 1
            for (int i = 2; i <= totalPodcasts.Count; i++)
            {
                // This is the (n-k)!
                if (i <= totalPodcasts.Count - 2)
                {
                    denom *= i;
                }

                // n!
                num *= i;
            }

            // If there is no more comparisons that can be made
            if (showdownResults.Count >= num / denom)
            {
                return Results.NoContent();
            }

            List<int> possibleIds = totalPodcasts.Where(tp => showdownResults.Count(sr => tp == sr.LosingPodcastId || tp == sr.WinningPodcastId) < totalPodcasts.Count - 1).ToList();

            Random random = new Random();


            // index of the first podcast
            int randomPodcast = random.Next(possibleIds.Count);

            // id of random podcast - first podcast Id
            var id = possibleIds[randomPodcast];

            // Remove the id of the podcast that has been selected or the one of the podcast that have already been compared to the podcast that has been selected.
            List<int> compareIds = totalPodcasts.Where(tp => tp != id && !showdownResults.Any(sr => (sr.WinningPodcastId == id && sr.LosingPodcastId == tp) || (sr.LosingPodcastId == id && sr.WinningPodcastId == tp))).ToList();

            // index of the second podcast
            int randomPodcast2 = random.Next(compareIds.Count);

            var id2 = compareIds[randomPodcast2];

            List<Podcast> showdownPodcasts = db.Podcasts.Where(p => p.Id == id || p.Id == id2).ToList();

            return Results.Ok(showdownPodcasts);
        });
    }

}
