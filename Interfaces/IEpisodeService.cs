﻿using System;
using PodcastAPI.Models;

namespace PodcastAPI.Interfaces;

public interface IEpisodeService
{
    Task<List<User>> GetFavoriteEpisodesAsync(int userId);

    Task<Episode> CreateEpisodeAsync(Episode episode);

    Task<Episode> UpdateEpisodeAsync(int id, Episode episode);

    Task<Episode> DeleteEpisodeAsync(int id);

    Task<bool> ToggleFavoriteEpisodeAsync(int episodeId, int userId);
}

