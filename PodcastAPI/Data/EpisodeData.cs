using System;
using PodcastAPI.Models;
namespace PodcastAPI.Data;

public class EpisodeData
{
    public static List<Episode> Episodes = new()
    {
        new()
        {
            Id = 1,
            Title = "The Vanishing of the Sodder Children",
            Description = "Explore the mysterious disappearance of five children from a West Virginia home on Christmas Eve in 1945.",
            Duration = 2540,
            ImageUrl = "",
            CreatedOn = new DateTime(2024, 10, 01),
            PodcastId = 1
        },
        new()
        {
            Id = 2,
            Title = "The Zodiac Killer",
            Description = "Delve into the infamous unsolved cases of the Zodiac Killer and the clues that continue to baffle investigators.",
            Duration = 2642,
            ImageUrl = "",
            CreatedOn = new DateTime(2024, 10, 08),
            PodcastId = 1
        },
        new()
        {
            Id = 3,
            Title = "Falling Flat: My Most Embarrassing Moments",
            Description = "Comedians share their most cringe-worthy moments and the life lessons learned from them.",
            Duration = 1830,
            ImageUrl = "",
            CreatedOn = new DateTime(2024, 10, 03),
            PodcastId = 2
        },
        new()
        {
            Id = 4,
            Title = "Parenting Fails: When Kids Outsmart You",
            Description = "A hilarious look at parenting mishaps and the unexpected wisdom that comes from raising kids.",
            Duration = 1756,
            ImageUrl = "",
            CreatedOn = new DateTime(2024, 10, 10),
            PodcastId = 2
        },
        new()
        {
            Id = 5,
            Title = "Backpacking Through Southeast Asia",
            Description = "Hear firsthand accounts from travelers navigating cultures, cuisines, and breathtaking landscapes.",
            Duration = 3573,
            ImageUrl = "",
            CreatedOn = new DateTime(2024, 09, 28),
            PodcastId = 3
        },
        new()
        {
            Id = 6,
            Title = "The Art of Slow Travel",
            Description = "Discover the joys of immersive travel experiences that prioritize connection over itinerary.",
            Duration = 3685,
            ImageUrl = "",
            CreatedOn = new DateTime(2024, 10, 05),
            PodcastId = 3
        },
        new()
        {
            Id = 7,
            Title = "The Psychology of First Impressions",
            Description = "Investigate how first impressions are formed and their lasting impact on our relationships.",
            Duration = 2193,
            ImageUrl = "",
            CreatedOn = new DateTime(2024, 10, 04),
            PodcastId = 4
        },
        new()
        {
            Id = 8,
            Title = "Why We Procrastinate: The Science Behind It",
            Description = "Explore the psychological factors that lead to procrastination and tips for overcoming it.",
            Duration = 2045,
            ImageUrl = "",
            CreatedOn = new DateTime(2024, 10, 01),
            PodcastId = 4
        },
        new()
        {
            Id = 9,
            Title = "Day in the Life of Brit Pt. 1",
            Description = "Brit travels to Chicago",
            Duration = 1034,
            ImageUrl = "",
            CreatedOn = new DateTime(2024, 10, 14),
            PodcastId = 5
        },
        new()
        {
            Id = 10,
            Title = "Day in the Life of Brit Pt. 2",
            Description = "Brit leaves Chicago",
            Duration = 263,
            ImageUrl = "",
            CreatedOn = new DateTime(2024, 10, 15),
            PodcastId = 5
        }
    };
}

