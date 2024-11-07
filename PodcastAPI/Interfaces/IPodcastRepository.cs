using System;
using PodcastAPI.Models;
using PodcastAPI.DTOs;

namespace PodcastAPI.Interfaces;

public interface IPodcastRepository
{
    Task<List<Podcast>> GetPodcastsAsync();

    Task<Podcast> GetPodcastByIdAsync(int podcastId);

    Task<List<Podcast>> GetFavoritePodcastsAsync(int userId);

    Task<Podcast> CreatePodcastAsync(PodcastSubmitDTO podcastSubmit);

    Task<Podcast> UpdatePodcastAsync(int id, PodcastSubmitDTO podcastSubmit);

    Task<Podcast> DeletePodcastAsync(int id);

    Task<string> ToggleFavoritePodcastAsync(int podcastId, int userId);

    Task<List<Podcast>> SearchPodcastbyTItle(string searchInput);

    Task<List<Podcast>> SearchFavoritePodcastbyTItle(string searchInput, int userId);
}

