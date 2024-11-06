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
    public DbSet<User> Users { get; set; }
    public DbSet<ShowdownResult> ShowdownResults { get; set; }

    public PodcastAPIDbContext(DbContextOptions<PodcastAPIDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.FavoriteEpisodes)
            .WithMany(e => e.UsersFavorited)
            .UsingEntity<FavoriteEpisode>();

        modelBuilder.Entity<User>()
            .HasMany(u => u.FavoritePodcasts)
            .WithMany(p => p.UsersFavorited)
            .UsingEntity<FavoritePodcast>();

        modelBuilder.Entity<Podcast>()
            .HasOne(p => p.User)
            .WithMany(u => u.Podcasts)
            .HasForeignKey(p => p.UserId)
            .IsRequired();

        modelBuilder.Entity<Podcast>()
            .HasMany(p => p.WinningShowdowns)
            .WithOne()
            .HasForeignKey(sr => sr.WinningPodcastId);

        modelBuilder.Entity<Podcast>()
            .HasMany(p => p.LosingShowdowns)
            .WithOne()
            .HasForeignKey(sr => sr.LosingPodcastId);

modelBuilder.Entity<Episode>().HasData(EpisodeData.Episodes);
        modelBuilder.Entity<FavoriteEpisode>().HasData(FavoriteEpisodeData.FavoriteEpisodes);
        modelBuilder.Entity<FavoritePodcast>().HasData(FavoritePodcastData.FavoritePodcasts);
        modelBuilder.Entity<Genre>().HasData(GenreData.Genres);
        modelBuilder.Entity<Podcast>().HasData(PodcastData.Podcasts);
        modelBuilder.Entity<ShowdownResult>().HasData(ShowdownResultsData.ShowdownResults);
        modelBuilder.Entity<User>().HasData(UserData.Users);
    }
}
