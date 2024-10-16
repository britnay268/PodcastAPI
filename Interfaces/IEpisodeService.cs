using System;
using PodcastAPI.Models;

namespace PodcastAPI.Interfaces;

public interface IEpisodeService
{
    Task<List<Episode>> GetFavoriteEpisodesAsync(int userId);

    Task<Episode> CreateEpisodeAsync(Episode episode);

    Task<Episode> UpdateEpisodeAsync(int id, Episode episode);

    Task<Episode> DeleteEpisodeAsync(int id);

    Task<FavoriteEpisode> ToggleFavoriteEpisodeAsync(int episodeId, int userId);
}

