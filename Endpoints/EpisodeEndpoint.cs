using System;
using PodcastAPI.Models;
using PodcastAPI.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace PodcastAPI.Endpoints;

public static class EpisodeEndpoint
{
	public static void MapEpisodeEndpoints(this IEndpointRouteBuilder routes)
	{
		var group = routes.MapGroup("").WithTags(nameof(Episode));

		group.MapPost("/episodes", async (IEpisodeService episodeService, Episode episode) =>
		{
			var episodeToCreate = await episodeService.CreateEpisodeAsync(episode);
			return Results.Created($"/episodes/{episodeToCreate.Id}", episodeToCreate);
		})
        .WithOpenApi()
        .Produces<Episode>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        group.MapDelete("/episodes/{id}", async (IEpisodeService episodeService, int id) =>
        {
            var episodeToDelete = await episodeService.DeleteEpisodeAsync(id);
            if (episodeToDelete == null)
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        })
        .WithOpenApi()
            .Produces<Episode>(StatusCodes.Status204NoContent);

        group.MapGet("/users/{userId}/episodes/favorite", async (IEpisodeService episodeService, int userId) =>
        {
            return await episodeService.GetFavoriteEpisodesAsync(userId);
        })
            .WithOpenApi()
            .Produces<List<Episode>>(StatusCodes.Status200OK);

        group.MapPut("/episodes/toggleFavorite", async (IEpisodeService episodeService, int episodeId, int userId) =>
        {
            var episodeToFavorite = await episodeService.ToggleFavoriteEpisodeAsync(userId, episodeId);

            if (episodeToFavorite)
            {
                return Results.Ok("Episode has been favorited!");
            }
            else
            {
                return Results.Ok("Episode has been unfavorited!");
            }
        })
           .WithOpenApi()
           .Produces<Episode>(StatusCodes.Status200OK)
           .Produces(StatusCodes.Status204NoContent);

        group.MapPut("/episodes/{id}", async (IEpisodeService episodeService, int id, Episode episode) =>
        {
            var episodeToUpdate = await episodeService.UpdateEpisodeAsync(id, episode);
            if (episodeToUpdate == null)
            {
                return Results.NotFound();
            }
            return Results.Ok("Episode has been updated!");
        })
           .WithOpenApi()
           .Produces<Episode>(StatusCodes.Status200OK)
           .Produces(StatusCodes.Status204NoContent);
    }
}

