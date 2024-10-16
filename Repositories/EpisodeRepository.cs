using System;
using PodcastAPI.Interfaces;
using PodcastAPI.Data;
using PodcastAPI.Models;

namespace PodcastAPI.Repositories;

public class EpisodeRepository : IEpisodeRepository
{
	private readonly PodcastAPIDbContext dbContext;

	public EpisodeRepository(PodcastAPIDbContext context)
	{
		dbContext = context;
	}

    public Task<Episode> CreateEpisodeAsync(Episode episode)
    {
        throw new NotImplementedException();
    }

    public Task<Episode> DeleteEpisodeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Episode>> GetFavoriteEpisodesAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<FavoriteEpisode> ToggleFavoriteEpisodeAsync(int episodeId, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Episode> UpdateEpisodeAsync(int id, Episode episode)
    {
        throw new NotImplementedException();
    }
}

