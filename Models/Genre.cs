using System;
namespace PodcastAPI.Models
{
	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Podcast> Podcasts { get; set; }
	}
}

