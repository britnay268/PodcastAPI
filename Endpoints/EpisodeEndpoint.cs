﻿using System;
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
            if (episodeToCreate == null)
            {
                return Results.NotFound("Podcast does not exist!");
            }
            return Results.Ok($"{episodeToCreate.Title} has been created!");
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
            return Results.Ok($"Episode {episodeToDelete.Title} has been deleted!");
        })
        .WithOpenApi()
        .Produces<Episode>(StatusCodes.Status204NoContent);

        group.MapGet("/users/{userId}/episodes/favorite", async (IEpisodeService episodeService, int userId) =>
        {
            var favoriteEpisode = await episodeService.GetFavoriteEpisodesAsync(userId);
            return favoriteEpisode;
        })
        .WithOpenApi()
        .Produces<List<Episode>>(StatusCodes.Status200OK);

        group.MapPut("/episodes/{episodeId}/toggleFavorite/{userId}", async (IEpisodeService episodeService, int episodeId, int userId) =>
        {
            var episodeToFavorite = await episodeService.ToggleFavoriteEpisodeAsync(episodeId, userId);

            return episodeToFavorite;
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

