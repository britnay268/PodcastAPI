using System;
using PodcastAPI.Models;
using PodcastAPI.Interfaces;
using PodcastAPI.DTOs;

namespace PodcastAPI.Endpoints;

public static class PodcastEndpoint
{
	public static void MapPodcastEndpoints(this IEndpointRouteBuilder routes)
	{
        var group = routes.MapGroup("").WithTags(nameof(Podcast));

        group.MapGet("/podcasts", async (IPodcastService podcastService, int userFavoritesId) =>
        {
            var podcasts = await podcastService.GetPodcastsAsync();
            return Results.Ok(podcasts.Select(p => new
            {
                p.Id,
                p.Title,
                p.Description,
                p.ImageUrl,
                p.CreatedOn,
                p.Genre,
                User = new
                {
                    p.User.Id,
                    p.User.Username,
                    p.User.FirstName,
                    p.User.LastName,
                    p.User.ImageUrl
                },
                EpisodeCount = p.Episodes.Count,
                Favorite = p.UsersFavorited.Any(uf => uf.Id == userFavoritesId)
            }));
        })
        .WithOpenApi()
        .Produces<List<Podcast>>(StatusCodes.Status200OK);

        group.MapGet("/podcasts/favorites/{userId}", async (IPodcastService podcastService, int userId) =>
        {
            var podcasts = await podcastService.GetFavoritePodcastsAsync(userId);
            return Results.Ok(podcasts.Select(p => new
            {
                p.Id,
                p.Title,
                p.Description,
                p.ImageUrl,
                p.CreatedOn,
                p.Genre,
                User = new
                {
                    p.User.Id,
                    p.User.Username,
                    p.User.FirstName,
                    p.User.LastName,
                    p.User.ImageUrl
                },
                EpisodeCount = p.Episodes.Count,
                Favorite = p.UsersFavorited.Any(uf => uf.Id == userId)
            }));
        })
        .WithOpenApi()
        .Produces<List<Podcast>>(StatusCodes.Status200OK);

        group.MapGet("/podcasts/{podcastId}", async (IPodcastService podcastService, int podcastId, int userFavoritesId) =>
        {
            var podcast = await podcastService.GetPodcastByIdAsync(podcastId);
            if (podcast == null)
            {
                return Results.NotFound("Invalid podcast id");
            }
            return Results.Ok(new
            {
                podcast.Id,
                podcast.Title,
                podcast.Description,
                podcast.ImageUrl,
                podcast.CreatedOn,
                podcast.Genre,
                User = new
                {
                    podcast.User.Id,
                    podcast.User.Username,
                    podcast.User.FirstName,
                    podcast.User.LastName,
                    podcast.User.ImageUrl
                },
                Episodes = podcast.Episodes.Select(e => new
                {
                    e.Id,
                    e.Title,
                    e.Duration,
                    e.ImageUrl,
                    e.Description,
                    e.CreatedOn,
                    Favorited = e.UsersFavorited.Any(uf => uf.Id == userFavoritesId)
                }),
                Favorite = podcast.UsersFavorited.Any(uf => uf.Id == userFavoritesId)
            });
        })
        .WithOpenApi()
        .Produces<Podcast>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/podcasts/{podcastId}/toggleFavorite/{userId}", async (IPodcastService podcastService, int podcastId, int userId) =>
        {
            string taskResponse = await podcastService.ToggleFavoritePodcastAsync(podcastId, userId);

            if (taskResponse == "Invalid User Id" || taskResponse == "Invalid Podcast Id")
            {
                return Results.NotFound(taskResponse);
            }
            return Results.Ok($"Podcast has been {taskResponse}!");
        })
        .WithOpenApi()
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/podcasts", async (IPodcastService podcastService, PodcastSubmitDTO podcastSubmit) =>
        {
            var addPodcast = await podcastService.CreatePodcastAsync(podcastSubmit);

            if (addPodcast.GenreId == -1)
            {
                return Results.NotFound("Invalid Genre Id");
            }
            if (addPodcast.UserId == -1)
            {
                return Results.NotFound("Invalid User Id");
            }

            return Results.Created($"/podcast/{addPodcast.Id}", addPodcast);
        })
        .WithOpenApi()
        .Produces<Podcast>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/podcasts/{podcastId}", async (IPodcastService podcastService, int podcastId, PodcastSubmitDTO podcastSubmit) =>
        {
            if (podcastSubmit.Id != podcastId)
            {
                return Results.BadRequest("Podcast Id in URI does not match Id in payload.");
            }

            var updatedPodcast = await podcastService.UpdatePodcastAsync(podcastId, podcastSubmit);

            if (updatedPodcast == null)
            {
                return Results.NotFound("Invalid Podcast Id");
            }
            if (updatedPodcast.GenreId == -1)
            {
                return Results.NotFound("Invalid Genre Id");
            }

            return Results.Ok(updatedPodcast);
        })
        .WithOpenApi()
        .Produces<Podcast>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("/podcasts/{podcastId}", async (IPodcastService podcastService, int podcastId) =>
        {
            var removePodcast = await podcastService.DeletePodcastAsync(podcastId);
            if (removePodcast == null)
            {
                return Results.NotFound("Invalid Podcast Id");
            }

            return Results.NoContent();
        })
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}

