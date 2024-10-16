using System;
using PodcastAPI.Interfaces;
using PodcastAPI.Data;
using PodcastAPI.Models;

namespace PodcastAPI.Repositories;

public class PodcastRepository : IPodcastRepository
{
    private readonly PodcastAPIDbContext dbContext;

    public PodcastRepository(PodcastAPIDbContext context)
    {
        dbContext = context;
    }

    public Task<Podcast> CreatePodcastAsync(Podcast podcast)
    {
        throw new NotImplementedException();
    }

    public Task<Podcast> DeletePodcastAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Podcast>> GetFavoritePodcastsAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Podcast> GetPodcastByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Podcast>> GetPodcastsAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<FavoritePodcast> ToggleFavoritePodcastAsync(int podcastId, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Podcast> UpdatePodcastAsync(int id, Podcast podcast)
    {
        throw new NotImplementedException();
    }
}

