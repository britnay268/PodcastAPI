using System;
using PodcastAPI.Models;
namespace PodcastAPI.Data;

public class FavoriteEpisodeData
{
	public static List<FavoriteEpisode> FavoriteEpisodes = new()
	{
		new() { Id = 1, UserId = 1, EpisodeId = 5 },
		new() { Id = 2, UserId = 1, EpisodeId = 9 },
		new() { Id = 3, UserId = 2, EpisodeId = 8 },
		new() { Id = 4, UserId = 4, EpisodeId = 7 },
		new() { Id = 5, UserId = 4, EpisodeId = 10 },
		new() { Id = 6, UserId = 3, EpisodeId = 1 },
		new() { Id = 7, UserId = 2, EpisodeId = 2 },
		new() { Id = 8, UserId = 3, EpisodeId = 5 },
		new() { Id = 9, UserId = 1, EpisodeId = 3 },
		new() { Id = 10, UserId = 2, EpisodeId = 5 },
		new() { Id = 11, UserId = 4, EpisodeId = 9 },
		new() { Id = 12, UserId = 2, EpisodeId = 6 },
		new() { Id = 13, UserId = 3, EpisodeId = 4 }
	};
}

