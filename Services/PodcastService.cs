using System;
using PodcastAPI.Interfaces;
using PodcastAPI.Models;
using PodcastAPI.DTOs;
namespace PodcastAPI.Services
{
    public class PodcastService : IPodcastService
    {
        private readonly IPodcastRepository _podcastRepository;

        public PodcastService(IPodcastRepository podcastRepository)
        {
            _podcastRepository = podcastRepository;
        }

        public async Task<Podcast> CreatePodcastAsync(PodcastSubmitDTO podcastSubmit)
        {
            return await _podcastRepository.CreatePodcastAsync(podcastSubmit);
        }

        public async Task<Podcast> DeletePodcastAsync(int id)
        {
            return await _podcastRepository.DeletePodcastAsync(id);
        }

        public async Task<List<Podcast>> GetFavoritePodcastsAsync(int userId)
        {
            return await _podcastRepository.GetFavoritePodcastsAsync(userId);
        }

        public async Task<Podcast> GetPodcastByIdAsync(int podcastId)
        {
            return await _podcastRepository.GetPodcastByIdAsync(podcastId);
        }

        public async Task<List<Podcast>> GetPodcastsAsync()
        {
            return await _podcastRepository.GetPodcastsAsync();
        }

        public async Task<string> ToggleFavoritePodcastAsync(int podcastId, int userId)
        {
            return await _podcastRepository.ToggleFavoritePodcastAsync(podcastId, userId);
        }

        public async Task<Podcast> UpdatePodcastAsync(int id, PodcastSubmitDTO podcastSubmit)
        {
            return await _podcastRepository.UpdatePodcastAsync(id, podcastSubmit);
        }
    }
}

