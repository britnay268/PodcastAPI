using System;
using PodcastAPI.Interfaces;
using PodcastAPI.Models;
namespace PodcastAPI.Services;

public class EpisodeService : IEpisodeService
{
    private readonly IEpisodeRepository _episodeRepository;

    public EpisodeService(IEpisodeRepository episodeRepository)
    {
        _episodeRepository = episodeRepository;
    }

    public async Task<Episode> CreateEpisodeAsync(Episode episode)
    {
        return await _episodeRepository.CreateEpisodeAsync(episode);
    }

    public async Task<Episode> DeleteEpisodeAsync(int id)
    {
        return await _episodeRepository.DeleteEpisodeAsync(id);
    }

    public async Task<List<User>> GetFavoriteEpisodesAsync(int userId)
    {
        return await _episodeRepository.GetFavoriteEpisodesAsync(userId);
    }

    public async Task<bool> ToggleFavoriteEpisodeAsync(int episodeId, int userId)
    {
        return await _episodeRepository.ToggleFavoriteEpisodeAsync(episodeId, userId);
    }

    public async Task<Episode> UpdateEpisodeAsync(int id, Episode episode)
    {
        return await _episodeRepository.UpdateEpisodeAsync(id, episode);
    }
}

