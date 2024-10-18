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

    public async Task<List<User>> GetFavoriteEpisodesAsync(int userId)
    {
        // To be tested
        return await dbContext.Users.Include(u => u.FavoriteEpisodes).Where(u => u.Id == userId).ToListAsync();
    }

    public async Task<bool> ToggleFavoriteEpisodeAsync(int episodeId, int userId)
    {
        var episodeToFavorite = await dbContext.Episodes.Include(e => e.UsersFavorited).SingleOrDefaultAsync(uf => uf.Id == episodeId);

        if (episodeToFavorite == null)
        {
            return false; 
        }

        var isFavorite = episodeToFavorite.UsersFavorited.Any(uf => uf.Id == userId);

        if (!isFavorite)
        {
            episodeToFavorite.UsersFavorited.Add(dbContext.Users.Find(userId));
        }
        else
        {
            episodeToFavorite.UsersFavorited.Remove(dbContext.Users.Find(userId));
        }

        await dbContext.SaveChangesAsync();
        return isFavorite;
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

