using System;
namespace PodcastAPI.Models
{
	public class FavoritePodcast
	{
        public int Id { get; set; }
        public int PodcastId { get; set; }
        public int UserId { get; set; }
    }
}

