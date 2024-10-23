using PodcastAPI.Models;

namespace PodcastAPI.DTOs
{
    public class EpisodeSubmitDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public int PodcastId { get; set; }
        public bool Favorite { get; set; } = false;
        public int UserId { get; set; }
    }
}
