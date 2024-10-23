using System;
using PodcastAPI.Models;
using PodcastAPI.Interfaces;

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
                Genres = p.Genres.Select(g => new
                {
                    g.Id,
                    g.Name,
                }),
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
                Genres = p.Genres.Select(g => new
                {
                    g.Id,
                    g.Name,
                }),
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
                Genres = podcast.Genres.Select(g => new
                {
                    g.Id,
                    g.Name,
                }),
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
    }
}

