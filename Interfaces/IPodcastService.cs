using System;
using PodcastAPI.Models;

namespace PodcastAPI.Interfaces;

public interface IPodcastService
{
    Task<List<Podcast>> GetPodcastsAsync();

    Task<Podcast> GetPodcastByIdAsync(int podcastId);

    Task<List<Podcast>> GetFavoritePodcastsAsync(int userId);

    Task<Podcast> CreatePodcastAsync(Podcast podcast);

    Task<Podcast> UpdatePodcastAsync(int id, Podcast podcast);

    Task<Podcast> DeletePodcastAsync(int id);

    Task<string> ToggleFavoritePodcastAsync(int podcastId, int userId);
}

