using System;
using PodcastAPI.DTOs;
using PodcastAPI.Models;

namespace PodcastAPI.Interfaces;

public interface IEpisodeService
{
    Task<List<User>> GetFavoriteEpisodesAsync(int userId);

    Task<Episode> GetSingleEpisode(int episodeId);

    Task<Episode> CreateEpisodeAsync(EpisodeSubmitDTO episodeSubmit);

    Task<Episode> UpdateEpisodeAsync(int id, EpisodeSubmitDTO episodeSubmit);

    Task<Episode> DeleteEpisodeAsync(int id);

    Task<IResult> ToggleFavoriteEpisodeAsync(int episodeId, int userId);
}

