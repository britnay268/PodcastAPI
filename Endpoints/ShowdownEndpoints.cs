using System;
using Microsoft.EntityFrameworkCore;
using PodcastAPI.Data;
using PodcastAPI.Models;

namespace PodcastAPI.Endpoints;

public static class ShowdownEndpoints
{
	public static void MapShowdownEndpoints(this IEndpointRouteBuilder routes)
	{
        var group = routes.MapGroup("").WithTags(nameof(ShowdownResult));

        group.MapPost("/showdown", (PodcastAPIDbContext db, ShowdownResult showdownResult) =>
        {
            
        });
    }
}

