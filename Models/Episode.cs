using System;
namespace PodcastAPI.Models;

public class Episode
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public int Duration { get; set; }
	public string ImageUrl { get; set; }
	public DateTime CreatedOn { get; set; }
	public int PodcastId { get; set; }
	public Podcast Podcast { get; set; }
}

