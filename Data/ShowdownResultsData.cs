using System;
using PodcastAPI.Models;
namespace PodcastAPI.Data;

public class ShowdownResultsData
{
    public static List<ShowdownResult> ShowdownResults = new()
    {
        new() { Id = 1, WinningPodcastId = 1, LosingPodcastId = 5, UserId = 1, GenreId = 7 },
        new() { Id = 2, WinningPodcastId = 5, LosingPodcastId = 3, UserId = 2, GenreId = 7 },
        new() { Id = 3, WinningPodcastId = 5, LosingPodcastId = 4, UserId = 3 },
        new() { Id = 4, WinningPodcastId = 5, LosingPodcastId = 1, UserId = 4, GenreId = 7 },
        new() { Id = 5, WinningPodcastId = 2, LosingPodcastId = 3, UserId = 1 }
    };
}

