using System;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PodcastAPI.Models
{
	public class Podcast
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<Episode> Episodes { get; set; }
        public List<User> UsersFavorited { get; set; }
        public List<ShowdownResult> WinningShowdowns { get; set; } = [];
        public List<ShowdownResult> LosingShowdowns { get; set; } = [];
        public int ShowdownWins => (
                WinningShowdowns.Count()
            );
        public int ShowdownLosses => (
                LosingShowdowns.Count()
            );
    }
}

