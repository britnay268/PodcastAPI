using System;
using PodcastAPI.DTOs;
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

    public async Task<Episode> GetSingleEpisode(int episodeId)
    {
        return await _episodeRepository.GetSingleEpisode(episodeId);
    }

    public async Task<Episode> CreateEpisodeAsync(EpisodeSubmitDTO episodeSubmit)
    {
        return await _episodeRepository.CreateEpisodeAsync(episodeSubmit);
    }

    public async Task<Episode> DeleteEpisodeAsync(int id)
    {
        return await _episodeRepository.DeleteEpisodeAsync(id);
    }

    public async Task<List<User>> GetFavoriteEpisodesAsync(int userId)
    {
        return await _episodeRepository.GetFavoriteEpisodesAsync(userId);
    }

    public async Task<IResult> ToggleFavoriteEpisodeAsync(int episodeId, int userId)
    {
        return await _episodeRepository.ToggleFavoriteEpisodeAsync(episodeId, userId);
    }

    public async Task<Episode> UpdateEpisodeAsync(int id, EpisodeSubmitDTO episodeSubmit)
    {
        return await _episodeRepository.UpdateEpisodeAsync(id, episodeSubmit);
    }
}

