using System;
namespace PodcastAPI.Models
{
	public class User
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateJoined { get; set; }
        public string Uid { get; set; }
        public List<Episode> FavoriteEpisodes { get; set; }
        public List<Podcast> FavoritePodcasts { get; set; }
        public List<Podcast> Podcasts { get; set; }
    }
}

