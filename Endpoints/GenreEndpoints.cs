using System;
using PodcastAPI.Models;

namespace PodcastAPI.Endpoints
{
	public static class GenreEndpoints
	{
        public static void MapGenreEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(Genre));
        }
    }
}

