using System;
using PodcastAPI.Interfaces;
using PodcastAPI.Data;
using PodcastAPI.Models;
using PodcastAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PodcastAPI.Repositories;

public class PodcastRepository : IPodcastRepository
{
    private readonly PodcastAPIDbContext dbContext;

    public PodcastRepository(PodcastAPIDbContext context)
    {
        dbContext = context;
    }

    public async Task<Podcast> CreatePodcastAsync(PodcastSubmitDTO podcastSubmit)
    {
        var genreExists = dbContext.Genres.Any(g => g.Id == podcastSubmit.GenreId);

        if (!genreExists)
        {
            return new Podcast { GenreId = -1 };
        }

        var userExists = dbContext.Users.Any(u => u.Id == podcastSubmit.UserId);

        if (!userExists)
        {
            return new Podcast { UserId = -1 };
        }

        Podcast? newPodcast = new Podcast
        {
            Title = podcastSubmit.Title,
            Description = podcastSubmit.Description,
            ImageUrl = podcastSubmit.ImageUrl,
            CreatedOn = DateTime.Now,
            UserId = podcastSubmit.UserId,
            GenreId = podcastSubmit.GenreId
        };

        dbContext.Podcasts.Add(newPodcast);
        await dbContext.SaveChangesAsync();
        return newPodcast;
    }

    public async Task<Podcast> DeletePodcastAsync(int id)
    {
        var podcastToDelete = await dbContext.Podcasts.SingleOrDefaultAsync(p => p.Id == id);
        if (podcastToDelete == null)
        {
            return null;
        }

        dbContext.Podcasts.Remove(podcastToDelete);
        await dbContext.SaveChangesAsync();

        return podcastToDelete;
    }

    public async Task<List<Podcast>> GetFavoritePodcastsAsync(int userId)
    {
        return await dbContext.Podcasts
            .Where(p => p.UsersFavorited.Any(uf => uf.Id == userId))
            .Include(p => p.User)
            .Include(p => p.Genre)
            .Include(p => p.Episodes)
            .Include(p => p.UsersFavorited)
            .OrderBy(p => p.Title)
            .ToListAsync();
    }

    public async Task<Podcast?> GetPodcastByIdAsync(int podcastId)
    {
        return await dbContext.Podcasts
            .Include(p => p.User)
            .Include(p => p.Genre)
            .Include(p => p.Episodes.OrderBy(e => e.CreatedOn))
            .ThenInclude(e => e.UsersFavorited)
            .Include(p => p.UsersFavorited)
            .SingleOrDefaultAsync(p => p.Id == podcastId);
    }

    public async Task<List<Podcast>> GetPodcastsAsync()
    {
        return await dbContext.Podcasts
            .Include(p => p.User)
            .Include(p => p.Genre)
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

    public async Task<Podcast?> UpdatePodcastAsync(int id, PodcastSubmitDTO podcastSubmit)
    {
        var existingPodcast = await dbContext.Podcasts
            .Include(p => p.Episodes)
            .Include(p => p.Genre)
            .SingleOrDefaultAsync(e => e.Id == id);

        if (existingPodcast == null)
        {
            return null;
        }

        var existingGenre = await dbContext.Genres.SingleOrDefaultAsync(g => g.Id == podcastSubmit.GenreId);

        if (existingGenre == null && podcastSubmit.GenreId != 0)
        {
            return new Podcast { GenreId = -1 };
        }

        existingPodcast.Title = podcastSubmit.Title ?? existingPodcast.Title;
        existingPodcast.Description = podcastSubmit.Description ?? existingPodcast.Description;
        existingPodcast.GenreId = podcastSubmit.GenreId != 0 ? podcastSubmit.GenreId : existingPodcast.GenreId;
        existingPodcast.ImageUrl = podcastSubmit.ImageUrl ?? existingPodcast.ImageUrl;

        await dbContext.SaveChangesAsync();
        return existingPodcast;
    }

    public async Task<List<Podcast>> SearchPodcastbyTItle(string searchInput)
    { 
        if (string.IsNullOrEmpty(searchInput))
        {
            return null;
        }

        var searchResults = await dbContext.Podcasts
            .Where(p => p.Title.ToLower().Contains(searchInput.ToLower()))
            .Include(p => p.User)
            .Include(p => p.Genre)
            .Include(p => p.Episodes)
            .Include(p => p.UsersFavorited)
            .OrderBy(p => p.Title)
            .ToListAsync();


        return searchResults;
    }

    public async Task<List<Podcast>> SearchFavoritePodcastbyTItle(string searchInput, int userId)
    { 
        if (string.IsNullOrEmpty(searchInput))
        {
            return null;
        }

        var searchResults = await dbContext.Podcasts
            .Where(p => p.UsersFavorited.Any(uf => uf.Id == userId) && p.Title.ToLower().Contains(searchInput.ToLower()))
            .Include(p => p.User)
            .Include(p => p.Genre)
            .Include(p => p.Episodes)
            .Include(p => p.UsersFavorited)
            .OrderBy(p => p.Title)
            .ToListAsync();

        return searchResults;
    }
}

