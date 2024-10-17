using System;
using PodcastAPI.Models;
namespace PodcastAPI.Data;

public class GenreData
{
	public static List<Genre> Genres = new()
	{
		new() { Id = 1, Name = "True Crime" },
		new() { Id = 2, Name = "Comedy" },
		new() { Id = 3, Name = "News and Politics" },
		new() { Id = 4, Name = "Business and Finance" },
		new() { Id = 5, Name = "Health and Wellness" },
		new() { Id = 6, Name = "Technology" },
		new() { Id = 7, Name = "Storytelling/Documentary" },
		new() { Id = 8, Name = "History" },
		new() { Id = 9, Name = "Science" },
		new() { Id = 10, Name = "Personal Development" }
	};
}

