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

    public async Task<Episode> CreateEpisodeAsync(Episode episode)
    {
        throw new NotImplementedException();
    }

    public async Task<Episode> DeleteEpisodeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Episode>> GetFavoriteEpisodesAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<FavoriteEpisode> ToggleFavoriteEpisodeAsync(int episodeId, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Episode> UpdateEpisodeAsync(int id, Episode episode)
    {
        throw new NotImplementedException();
    }
}

