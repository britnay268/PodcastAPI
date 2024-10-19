using System;
using PodcastAPI.Interfaces;
using PodcastAPI.Data;
using PodcastAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PodcastAPI.Repositories;

public class PodcastRepository : IPodcastRepository
{
    private readonly PodcastAPIDbContext dbContext;

    public PodcastRepository(PodcastAPIDbContext context)
    {
        dbContext = context;
    }

    public async Task<Podcast> CreatePodcastAsync(Podcast podcast)
    {
        throw new NotImplementedException();
    }

    public async Task<Podcast> DeletePodcastAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Podcast>> GetFavoritePodcastsAsync(int userId)
    {
        return await dbContext.Podcasts
            .Where(p => p.UsersFavorited.Any(uf => uf.Id == userId))
            .Include(p => p.User)
            .Include(p => p.Genres)
            .Include(p => p.Episodes)
            .Include(p => p.UsersFavorited)
            .OrderBy(p => p.Title)
            .ToListAsync();
    }

    public async Task<Podcast?> GetPodcastByIdAsync(int podcastId)
    {
        return await dbContext.Podcasts
            .Include(p => p.User)
            .Include(p => p.Genres)
            .Include(p => p.Episodes.OrderBy(e => e.CreatedOn))
            .ThenInclude(e => e.UsersFavorited)
            .Include(p => p.UsersFavorited)
            .SingleOrDefaultAsync(p => p.Id == podcastId);
    }

    public async Task<List<Podcast>> GetPodcastsAsync()
    {
        return await dbContext.Podcasts
            .Include(p => p.User)
            .Include(p => p.Genres)
            .Include(p => p.Episodes)
            .Include(p => p.UsersFavorited)
            .OrderBy(p => p.Title)
            .ToListAsync();
    }

    public async Task<string> ToggleFavoritePodcastAsync(int podcastId, int userId)
    {
        User? user = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return "Invalid User Id";
        }

        Podcast? podcast = await dbContext.Podcasts.SingleOrDefaultAsync(p => p.Id == podcastId);
        
        if (podcast == null)
        {
            return "Invalid Podcast Id";
        }

        FavoritePodcast? favoritePodcast = await dbContext.FavoritePodcasts.FirstOrDefaultAsync(fp => fp.UserId == userId && fp.PodcastId == podcastId);
        
        //If podcast is favorited, task will unfavorite
        string returnMessage = favoritePodcast != null ? "unfavorited" : "favorited"; 

        if (favoritePodcast == null)
        {
            dbContext.FavoritePodcasts.Add(new FavoritePodcast { PodcastId = podcastId, UserId = userId });
        }
        else
        {
            dbContext.FavoritePodcasts.Remove(favoritePodcast);
        }
        await dbContext.SaveChangesAsync();
        return returnMessage;
    }

    public async Task<Podcast> UpdatePodcastAsync(int id, Podcast podcast)
    {
        throw new NotImplementedException();
    }
}

