using System;
namespace PodcastAPI.Models
{
	public class FavoriteEpisode
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int EpisodeId { get; set; }
	}
}

