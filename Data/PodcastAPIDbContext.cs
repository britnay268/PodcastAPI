using System;
using Microsoft.EntityFrameworkCore;
using PodcastAPI.Models;

namespace PodcastAPI.Data;

public class PodcastAPIDbContext : DbContext
{
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Podcast> Podcasts { get; set; }
    public DbSet<FavoriteEpisode> FavoriteEpisodes { get; set; }
    public DbSet<FavoritePodcast> FavoritePodcasts { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<PodcastGenre> PodcastGenres { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ShowdownResult> ShowdownResults { get; set; }

    public PodcastAPIDbContext(DbContextOptions<PodcastAPIDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
