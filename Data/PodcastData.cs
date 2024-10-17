using System;
using PodcastAPI.Models;
namespace PodcastAPI.Data;

public class PodcastData
{
    public static List<Podcast> Podcasts = new()
    {
        new()
        {
            Id = 1,
            Title = "Mystery Unraveled",
            Description = "Dive into intriguing unsolved mysteries and explore the stories behind them.",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQcE9K4DhKIoRe3InWlLAZ_kn1OtDtFXOjvPQ&s",
            CreatedOn = new DateTime(2023, 04, 14),
            UserId = 1
        },
        new()
        {
            Id = 2,
            Title = "Laughs and Lessons",
            Description = "A comedic take on life’s lessons, featuring funny anecdotes and insightful interviews.",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZRw85bJb4AyflJ3CYLIEK_Wmv3Aj0Fe0Ubw&s",
            CreatedOn = new DateTime(2010, 03, 20),
            UserId = 4
        },
        new()
        {
            Id = 3,
            Title = "Wanderlust Chronicles",
            Description = "Journey around the globe with travelers sharing their adventures and travel tips.",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ9991LNdmmk7rx9mQl7TeZuEHRXADOvD73A7V_TqljXbajmcMWn6cb0k1tBcSnTbEXAe0&usqp=CAU",
            CreatedOn = new DateTime(2024, 08, 01),
            UserId = 3
        },
        new()
        {
            Id = 4,
            Title = "The Science of Us",
            Description = "Explore the fascinating intersection of science and human behavior, uncovering what makes us tick.",
            ImageUrl = "https://plus.unsplash.com/premium_photo-1664195074951-fe91ec456eed?fm=jpg&q=60&w=3000[…]M3wxMjA3fDB8MHxzZWFyY2h8MXx8cG9kY2FzdHxlbnwwfHwwfHx8MA%3D%3D",
            CreatedOn = new DateTime(2020, 09, 15),
            UserId = 2
        },
        new()
        {
            Id = 5,
            Title = "Brit's World",
            Description = "She wanted more than one podcast, so she got it.",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZRw85bJb4AyflJ3CYLIEK_Wmv3Aj0Fe0Ubw&s",
            CreatedOn = new DateTime(2024, 10, 12),
            UserId = 4
        }
	}
}

