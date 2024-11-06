using System;
using PodcastAPI.Models;
using PodcastAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace PodcastAPI.Endpoints
{
	public static class GenreEndpoints
	{
        public static void MapGenreEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(Genre));

            group.MapGet("/genres", (PodcastAPIDbContext db) =>
            {
                return db.Genres.Select(genre => new
                {
                    Id = genre.Id,
                    Name = genre.Name,
                });
            });

            group.MapGet("/podcasts/genre/{genreId}", async (PodcastAPIDbContext db, int genreId, int userFavoritesId) =>
            {
                var podcastByGenre = await db.Podcasts
                    .Where(p => p.GenreId == genreId)
                    .Include(p => p.User)
                    .Include(p => p.Genre)
                    .Include(p => p.Episodes)
                    .Include(p => p.UsersFavorited)
                    .Include(p => p.WinningShowdowns)
                    .Include(p => p.LosingShowdowns)
                    .OrderBy(p => p.Title)
                    .ToListAsync();

                if (podcastByGenre.Count == 0)
                {
                    return Results.NotFound("There are no podcast with the genreId.");
                }

                return Results.Ok(podcastByGenre.Select(pg => new
                {
                    pg.Id,
                    pg.Title,
                    pg.Description,
                    pg.ImageUrl,
                    pg.CreatedOn,
                    pg.Genre,
                    User = new
                    {
                        pg.User.Id,
                        pg.User.Username,
                        pg.User.FirstName,
                        pg.User.LastName,
                        pg.User.ImageUrl
                    },
                    EpisodeCount = pg.Episodes.Count,
                    Favorite = pg.UsersFavorited.Any(uf => uf.Id == userFavoritesId),
                    pg.ShowdownWins,
                    pg.ShowdownLosses
                }));
            });
        }
    }
}

