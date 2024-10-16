using System;
using PodcastAPI.Models;

namespace PodcastAPI.Interfaces
{
	public interface IPodcastRepository
	{
        Task<List<Podcast>> GetPodcastsAsync(int userId);

        Task<Podcast> GetPodcastByIdAsync(int userId);

        Task<List<Podcast>> GetFavoritePodcastsAsync(int userId);

        Task<Podcast> CreatePodcastAsync(Podcast podcast);

        Task<Podcast> UpdatePodcastAsync(int id, Podcast podcast);

        Task<Podcast> DeletePodcastAsync(int id);

        Task<FavoritePodcast> ToggleFavoritePodcastAsync(int podcastId, int userId);
    }
}

