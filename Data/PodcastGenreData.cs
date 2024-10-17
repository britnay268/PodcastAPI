using System;
using PodcastAPI.Models;
namespace PodcastAPI.Data;

public class PodcastGenreData
{
	public static List<PodcastGenre> PodcastGenres = new()
	{
		new() { Id = 1, PodcastId = 1, GenreId = 7 },
		new() { Id = 2, PodcastId = 1, GenreId = 1 },
		new() { Id = 3, PodcastId = 2, GenreId = 2 },
		new() { Id = 4, PodcastId = 2, GenreId = 10 },
		new() { Id = 5, PodcastId = 3, GenreId = 7 },
		new() { Id = 6, PodcastId = 3, GenreId = 10 },
		new() { Id = 7, PodcastId = 4, GenreId = 9 },
		new() { Id = 8, PodcastId = 4, GenreId = 5 },
		new() { Id = 9, PodcastId = 5, GenreId = 7 }
	};
}

