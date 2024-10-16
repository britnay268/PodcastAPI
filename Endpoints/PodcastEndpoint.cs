using System;
using PodcastAPI.Models;
using PodcastAPI.Interfaces;

namespace PodcastAPI.Endpoints;

public static class PodcastEndpoint
{
	public static void MapPodcastEndpoints(this IEndpointRouteBuilder routes)
	{
        var group = routes.MapGroup("").WithTags(nameof(Podcast));
    }
}

