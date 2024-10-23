using System;
using PodcastAPI.Models;
using PodcastAPI.Interfaces;
using PodcastAPI.DTOs;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.AspNetCore.Mvc;

namespace PodcastAPI.Endpoints;

public static class EpisodeEndpoint
{
	public static void MapEpisodeEndpoints(this IEndpointRouteBuilder routes)
	{
		var group = routes.MapGroup("").WithTags(nameof(Episode));

        group.MapGet("/episodes/{episodeId}", async (IEpisodeService episodeService, int episodeId, int userId) =>
        {
            Episode? episode = await episodeService.GetSingleEpisode(episodeId);
            if (episode == null)
            {
                return Results.NotFound("Invalid Episode Id");
            }
            return Results.Ok(new
            {
                episode.Id,
                episode.Title,
                episode.Description,
                episode.Duration,
                episode.ImageUrl,
                episode.PodcastId,
                Favorite = episode.UsersFavorited.Any(u => u.Id == userId)
            });
        })
        .WithOpenApi()
        .Produces<Episode>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound); ;

		group.MapPost("/episodes", async (IEpisodeService episodeService, EpisodeSubmitDTO episodeSubmit) =>
		{
			var episodeToCreate = await episodeService.CreateEpisodeAsync(episodeSubmit);
            if (episodeToCreate == null)
            {
                return Results.NotFound("Podcast does not exist!");
            }
            if (episodeSubmit.Favorite)
            {
                var episodeFavorited = await episodeService.ToggleFavoriteEpisodeAsync(episodeToCreate.Id, episodeSubmit.UserId);
                //If episodeFavorited returns a NotFound, it indicates that the UserId in episodeSubmit does not correspond to a user in the database
                if (episodeFavorited is Microsoft.AspNetCore.Http.HttpResults.NotFound<string>)
                {
                    return Results.Ok($"{episodeToCreate.Title} has been created but userId is invalid");
                }
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

        group.MapPut("/episodes/{id}", async (IEpisodeService episodeService, int id, EpisodeSubmitDTO episodeSubmit) =>
        {
            var episodeToUpdate = await episodeService.UpdateEpisodeAsync(id, episodeSubmit);
            if (episodeToUpdate == null)
            {
                return Results.NotFound();
            }
            //Toggle favorite status only if different from current status
            if (episodeSubmit.Favorite != episodeToUpdate.UsersFavorited.Any(u => u.Id == episodeSubmit.UserId))
            {
                var episodeFavorited = await episodeService.ToggleFavoriteEpisodeAsync(id, episodeSubmit.UserId);
                //If episodeFavorited returns a NotFound, it indicates that the UserId in episodeSubmit does not correspond to a user in the database
                if (episodeFavorited is Microsoft.AspNetCore.Http.HttpResults.NotFound<string>)
                {
                    return Results.Ok($"Episode has been updated but userId is invalid");
                }
            }
            return Results.Ok("Episode has been updated!");
        })
        .WithOpenApi()
        .Produces<Episode>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);
    }
}

