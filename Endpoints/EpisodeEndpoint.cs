using System;
using PodcastAPI.Models;
using PodcastAPI.Interfaces;

namespace PodcastAPI.Endpoints;

public static class EpisodeEndpoint
{
	public static void MapEpisodeEndpoints(this IEndpointRouteBuilder routes)
	{
		var group = routes.MapGroup("").WithTags(nameof(Episode));

	}
}

