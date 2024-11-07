using PodcastAPI.Models;

namespace PodcastAPI.DTOs
{
    public class PodcastSubmitDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
        public int GenreId { get; set; }
    }
}
