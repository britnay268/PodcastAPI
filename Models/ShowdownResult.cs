using System;
namespace PodcastAPI.Models
{
	public class ShowdownResult
	{
        public int Id { get; set; }
        public int WinningPodcastId { get; set; }
        public int LosingPodcastId { get; set; }
    }
}

