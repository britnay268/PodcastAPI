using System;
using PodcastAPI.Interfaces;
using PodcastAPI.Data;
using PodcastAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PodcastAPI.Repositories;

public class EpisodeRepository : IEpisodeRepository
{
	private readonly PodcastAPIDbContext dbContext;

	public EpisodeRepository(PodcastAPIDbContext context)
	{
		dbContext = context;
	}

    public async Task<Episode> CreateEpisodeAsync(Episode episode)
    {
        dbContext.Episodes.Add(episode);
        await dbContext.SaveChangesAsync();
        return episode;
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

    public async Task<List<Episode>> GetFavoriteEpisodesAsync(int userId)
    {
        // To be tested
        return await dbContext.Episodes.Include(u => u.UsersFavorited).Where(u => u.Id == userId).ToListAsync();
    }

    public async Task<bool> ToggleFavoriteEpisodeAsync(int episodeId, int userId, FavoriteEpisode favoriteEpisode)
    {
        var episodeToFavorite = await dbContext.FavoriteEpisodes.SingleOrDefaultAsync(fe => fe.EpisodeId == episodeId && fe.UserId == userId);

        if (episodeToFavorite == null)
        {
            dbContext.FavoriteEpisodes.Add(favoriteEpisode);
            return true;
        }
        else
        {
            dbContext.FavoriteEpisodes.Remove(episodeToFavorite);
            return false;
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task<Episode> UpdateEpisodeAsync(int id, Episode episode)
    {
        var existingEpisode = await dbContext.Episodes.FindAsync(id);

        if (existingEpisode == null)
        {
            return null;
        }

        existingEpisode.Title = episode.Title ?? existingEpisode.Title;
        existingEpisode.Description = episode.Description ?? existingEpisode.Description;
        existingEpisode.Duration = episode.Duration != 0 ? episode.Duration : existingEpisode.Duration;
        existingEpisode.ImageUrl = episode.ImageUrl ?? existingEpisode.ImageUrl;
        existingEpisode.CreatedOn = episode.CreatedOn != null ? episode.CreatedOn : existingEpisode.CreatedOn;
        existingEpisode.PodcastId = episode.PodcastId != 0 ? episode.PodcastId : existingEpisode.PodcastId;

        await dbContext.SaveChangesAsync();
        return existingEpisode;
    }
}

