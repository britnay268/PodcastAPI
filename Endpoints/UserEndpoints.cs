using System;
using PodcastAPI.Models;
using PodcastAPI.Data;

namespace PodcastAPI.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("").WithTags(nameof(User));

        group.MapPost("/checkuser", (PodcastAPIDbContext db, User userToCheck) =>
        {
            User? user = db.Users.FirstOrDefault(u => u.Uid == userToCheck.Uid);

            if (user == null)
            {
                return Results.NotFound("User does not have an account.");
            }

            return Results.Ok(user);
        });
    }
}

