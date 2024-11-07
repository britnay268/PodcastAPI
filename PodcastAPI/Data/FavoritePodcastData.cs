using System;
using PodcastAPI.Models;
namespace PodcastAPI.Data;

public class FavoritePodcastData
{
    public static List<FavoritePodcast> FavoritePodcasts = new()
    {
        new() { Id = 1, UserId = 1, PodcastId = 3 },
        new() { Id = 2, UserId = 4, PodcastId = 5 },
        new() { Id = 3, UserId = 1, PodcastId = 2 },
        new() { Id = 4, UserId = 4, PodcastId = 4 },
        new() { Id = 5, UserId = 3, PodcastId = 1 },
        new() { Id = 6, UserId = 1, PodcastId = 4 },
        new() { Id = 7, UserId = 2, PodcastId = 5 }
    };
}

