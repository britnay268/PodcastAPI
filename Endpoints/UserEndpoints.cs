using System;
using PodcastAPI.Models;
using PodcastAPI.Data;
using PodcastAPI.DTOs;

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

        group.MapPost("/users", (PodcastAPIDbContext db, NewUser newUser) =>
        {
            if (db.Users.Any(u => u.Uid == newUser.Uid))
            {
                return Results.BadRequest("User is already registered");
            }

            User addUser = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Username = newUser.Username,
                ImageUrl = newUser.ImageUrl,
                Uid = newUser.Uid,
                DateJoined = DateTime.Now,
            };

            db.Users.Add(addUser);
            db.SaveChanges();
            return Results.Created("/users", addUser);
        });
    }
}

