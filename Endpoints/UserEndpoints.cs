using System;
using PodcastAPI.Models;
using PodcastAPI.Data;

namespace PodcastAPI.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("").WithTags(nameof(User));
    }
}

