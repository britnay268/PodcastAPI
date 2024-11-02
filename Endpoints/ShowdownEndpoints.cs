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
                UserId = showdownResult.UserId
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

            return Results.Ok();
        });
    }
}

