using System;
using PodcastAPI.Interfaces;
using PodcastAPI.Data;
using PodcastAPI.Models;
using Microsoft.EntityFrameworkCore;
using PodcastAPI.DTOs;

namespace PodcastAPI.Repositories;

public class EpisodeRepository : IEpisodeRepository
{
	private readonly PodcastAPIDbContext dbContext;

	public EpisodeRepository(PodcastAPIDbContext context)
	{
		dbContext = context;
	}

    public async Task<Episode?> GetSingleEpisode(int episodeId)
    {
        return await dbContext.Episodes
            .Include(e => e.UsersFavorited)
            .SingleOrDefaultAsync(e => e.Id == episodeId);
    }
    public async Task<Episode?> CreateEpisodeAsync(EpisodeSubmitDTO episodeSubmit)
    {
        var podcastExists = dbContext.Podcasts.Any(p => p.Id == episodeSubmit.PodcastId);

        if (!podcastExists)
        {
            return null;
        }

        Episode? newEpisode = new Episode
        {
            Title = episodeSubmit.Title,
            Description = episodeSubmit.Description,
            Duration = episodeSubmit.Duration,
            ImageUrl = episodeSubmit.ImageUrl,
            CreatedOn = DateTime.Now,
            PodcastId = episodeSubmit.PodcastId
        };

        dbContext.Episodes.Add(newEpisode);
        await dbContext.SaveChangesAsync();
        return newEpisode;
    }

    public async Task<Episode> DeleteEpisodeAsync(int id)
    {
        var episodeToDelete = await dbContext.Episodes.SingleOrDefaultAsync(e => e.Id == id);
        if (episodeToDelete == null)
        {
            return null;
        }

        dbContext.Episodes.Remove(episodeToDelete);
        await dbContext.SaveChangesAsync();

        return episodeToDelete;
    }

    public async Task<List<User>> GetFavoriteEpisodesAsync(int userId)
    {
        // To be tested
        return await dbContext.Users.Include(u => u.FavoriteEpisodes).ThenInclude(fe => fe.Podcast).Where(u => u.Id == userId).ToListAsync();
    }

    public async Task<IResult> ToggleFavoriteEpisodeAsync(int episodeId, int userId)
    {
        var episodeToFavorite = await dbContext.Episodes
            .Include(e => e.UsersFavorited)
            .SingleOrDefaultAsync(e => e.Id == episodeId);

        if (episodeToFavorite == null)
        {
            return Results.NotFound("Episode does not exist!");
        }

        var isFavorite = episodeToFavorite.UsersFavorited.Any(uf => uf.Id == userId);


        var user = await dbContext.Users.Include(u => u.FavoriteEpisodes).FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return Results.NotFound("User does not exist."); 
        }

        if (!isFavorite)
        {
            episodeToFavorite.UsersFavorited.Add(user);
        }
        else
        {
            episodeToFavorite.UsersFavorited.Remove(user);
        }

        await dbContext.SaveChangesAsync();

        return Results.Ok(isFavorite ? "Episode is unfavorited" : "Episode is favorited");
    }

    public async Task<Episode?> UpdateEpisodeAsync(int id, EpisodeSubmitDTO episodeSubmit)
    {
        var existingEpisode = await dbContext.Episodes.Include(e => e.UsersFavorited).SingleOrDefaultAsync(e => e.Id == id);

        if (existingEpisode == null)
        {
            return null;
        }

        existingEpisode.Title = episodeSubmit.Title ?? existingEpisode.Title;
        existingEpisode.Description = episodeSubmit.Description ?? existingEpisode.Description;
        existingEpisode.Duration = episodeSubmit.Duration != 0 ? episodeSubmit.Duration : existingEpisode.Duration;
        existingEpisode.ImageUrl = episodeSubmit.ImageUrl ?? existingEpisode.ImageUrl;

        await dbContext.SaveChangesAsync();
        return existingEpisode;
    }
}

