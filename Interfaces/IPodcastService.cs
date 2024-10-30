using System;
using PodcastAPI.Models;
using PodcastAPI.DTOs;

namespace PodcastAPI.Interfaces;

public interface IPodcastService
{
    Task<List<Podcast>> GetPodcastsAsync();

    Task<Podcast> GetPodcastByIdAsync(int podcastId);

    Task<List<Podcast>> GetFavoritePodcastsAsync(int userId);

    Task<Podcast> CreatePodcastAsync(PodcastSubmitDTO podcastSubmit);

    Task<Podcast> UpdatePodcastAsync(int id, PodcastSubmitDTO podcastSubmit);

    Task<Podcast> DeletePodcastAsync(int id);

    Task<string> ToggleFavoritePodcastAsync(int podcastId, int userId);
}

