using System;
using PodcastAPI.Interfaces;
using PodcastAPI.Models;
namespace PodcastAPI.Services
{
    public class PodcastService : IPodcastService
    {
        private readonly IPodcastRepository _podcastRepository;

        public PodcastService(IPodcastRepository podcastRepository)
        {
            _podcastRepository = podcastRepository;
        }

        public async Task<Podcast> CreatePodcastAsync(Podcast podcast)
        {
            return await _podcastRepository.CreatePodcastAsync(podcast);
        }

        public async Task<Podcast> DeletePodcastAsync(int id)
        {
            return await _podcastRepository.DeletePodcastAsync(id);
        }

        public async Task<List<Podcast>> GetFavoritePodcastsAsync(int userId)
        {
            return await _podcastRepository.GetFavoritePodcastsAsync(userId);
        }

        public async Task<Podcast> GetPodcastByIdAsync(int userId)
        {
            return await _podcastRepository.GetPodcastByIdAsync(userId);
        }

        public async Task<List<Podcast>> GetPodcastsAsync(int userId)
        {
            return await _podcastRepository.GetPodcastsAsync(userId);
        }

        public async Task<FavoritePodcast> ToggleFavoritePodcastAsync(int podcastId, int userId)
        {
            return await _podcastRepository.ToggleFavoritePodcastAsync(podcastId, userId);
        }

        public async Task<Podcast> UpdatePodcastAsync(int id, Podcast podcast)
        {
            return await _podcastRepository.UpdatePodcastAsync(id, podcast);
        }
    }
}

