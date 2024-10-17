using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PodcastAPI.Migrations
{
    public partial class MVPMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShowdownResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WinningPodcastId = table.Column<int>(type: "integer", nullable: false),
                    LosingPodcastId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowdownResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Podcasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Podcasts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PodcastId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Podcasts_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritePodcasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PodcastId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePodcasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritePodcasts_Podcasts_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritePodcasts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    PodcastId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodcastGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastGenres_Podcasts_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteEpisodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    EpisodeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteEpisodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteEpisodes_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteEpisodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "True Crime" },
                    { 2, "Comedy" },
                    { 3, "News and Politics" },
                    { 4, "Business and Finance" },
                    { 5, "Health and Wellness" },
                    { 6, "Technology" },
                    { 7, "Storytelling/Documentary" },
                    { 8, "History" },
                    { 9, "Science" },
                    { 10, "Personal Development" }
                });

            migrationBuilder.InsertData(
                table: "ShowdownResults",
                columns: new[] { "Id", "LosingPodcastId", "WinningPodcastId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 3, 5 },
                    { 3, 4, 5 },
                    { 4, 1, 5 },
                    { 5, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateJoined", "FirstName", "ImageUrl", "LastName", "Uid", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "", "Berka", "gKwUrKOtRCgw7JjrbxJrbf612dt2", "alexberka" },
                    { 2, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max", "", "Jones", "5cMGwFoo4VfmsK04V8TXIciut862", "maxjones" },
                    { 3, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Josh", "", "Gochey", "kTXfa5EXDtUWx6PqVcRMJPBVcGZ2", "joshgochey" },
                    { 4, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brit", "", "Gore", "qGLQ1gzuAmTsgtAXAh7TT3YlkEE2", "britgore" }
                });

            migrationBuilder.InsertData(
                table: "Podcasts",
                columns: new[] { "Id", "CreatedOn", "Description", "ImageUrl", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dive into intriguing unsolved mysteries and explore the stories behind them.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQcE9K4DhKIoRe3InWlLAZ_kn1OtDtFXOjvPQ&s", "Mystery Unraveled", 1 },
                    { 2, new DateTime(2010, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "A comedic take on life’s lessons, featuring funny anecdotes and insightful interviews.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZRw85bJb4AyflJ3CYLIEK_Wmv3Aj0Fe0Ubw&s", "Laughs and Lessons", 4 },
                    { 3, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Journey around the globe with travelers sharing their adventures and travel tips.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ9991LNdmmk7rx9mQl7TeZuEHRXADOvD73A7V_TqljXbajmcMWn6cb0k1tBcSnTbEXAe0&usqp=CAU", "Wanderlust Chronicles", 3 },
                    { 4, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explore the fascinating intersection of science and human behavior, uncovering what makes us tick.", "https://plus.unsplash.com/premium_photo-1664195074951-fe91ec456eed?fm=jpg&q=60&w=3000[…]M3wxMjA3fDB8MHxzZWFyY2h8MXx8cG9kY2FzdHxlbnwwfHwwfHx8MA%3D%3D", "The Science of Us", 2 },
                    { 5, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "She wanted more than one podcast, so she got it.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZRw85bJb4AyflJ3CYLIEK_Wmv3Aj0Fe0Ubw&s", "Brit's World", 4 }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "Id", "CreatedOn", "Description", "Duration", "ImageUrl", "PodcastId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explore the mysterious disappearance of five children from a West Virginia home on Christmas Eve in 1945.", 2540, "", 1, "The Vanishing of the Sodder Children" },
                    { 2, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delve into the infamous unsolved cases of the Zodiac Killer and the clues that continue to baffle investigators.", 2642, "", 1, "The Zodiac Killer" },
                    { 3, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedians share their most cringe-worthy moments and the life lessons learned from them.", 1830, "", 2, "Falling Flat: My Most Embarrassing Moments" },
                    { 4, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "A hilarious look at parenting mishaps and the unexpected wisdom that comes from raising kids.", 1756, "", 2, "Parenting Fails: When Kids Outsmart You" },
                    { 5, new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hear firsthand accounts from travelers navigating cultures, cuisines, and breathtaking landscapes.", 3573, "", 3, "Backpacking Through Southeast Asia" },
                    { 6, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover the joys of immersive travel experiences that prioritize connection over itinerary.", 3685, "", 3, "The Art of Slow Travel" },
                    { 7, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investigate how first impressions are formed and their lasting impact on our relationships.", 2193, "", 4, "The Psychology of First Impressions" },
                    { 8, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explore the psychological factors that lead to procrastination and tips for overcoming it.", 2045, "", 4, "Why We Procrastinate: The Science Behind It" },
                    { 9, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brit travels to Chicago", 1034, "", 5, "Day in the Life of Brit Pt. 1" },
                    { 10, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brit leaves Chicago", 263, "", 5, "Day in the Life of Brit Pt. 2" }
                });

            migrationBuilder.InsertData(
                table: "FavoritePodcasts",
                columns: new[] { "Id", "PodcastId", "UserId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 5, 4 },
                    { 3, 2, 1 },
                    { 4, 4, 4 },
                    { 5, 1, 3 },
                    { 6, 4, 1 },
                    { 7, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "PodcastGenres",
                columns: new[] { "Id", "GenreId", "PodcastId" },
                values: new object[,]
                {
                    { 1, 7, 1 },
                    { 2, 1, 1 },
                    { 3, 2, 2 },
                    { 4, 10, 2 },
                    { 5, 7, 3 },
                    { 6, 10, 3 },
                    { 7, 9, 4 },
                    { 8, 5, 4 },
                    { 9, 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "FavoriteEpisodes",
                columns: new[] { "Id", "EpisodeId", "UserId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 9, 1 },
                    { 3, 8, 2 },
                    { 4, 7, 4 },
                    { 5, 10, 4 },
                    { 6, 1, 3 },
                    { 7, 2, 2 },
                    { 8, 5, 3 },
                    { 9, 3, 1 },
                    { 10, 5, 2 },
                    { 11, 9, 4 },
                    { 12, 6, 2 },
                    { 13, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_PodcastId",
                table: "Episodes",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteEpisodes_EpisodeId",
                table: "FavoriteEpisodes",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteEpisodes_UserId",
                table: "FavoriteEpisodes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePodcasts_PodcastId",
                table: "FavoritePodcasts",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePodcasts_UserId",
                table: "FavoritePodcasts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastGenres_GenreId",
                table: "PodcastGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastGenres_PodcastId",
                table: "PodcastGenres",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Podcasts_UserId",
                table: "Podcasts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteEpisodes");

            migrationBuilder.DropTable(
                name: "FavoritePodcasts");

            migrationBuilder.DropTable(
                name: "PodcastGenres");

            migrationBuilder.DropTable(
                name: "ShowdownResults");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Podcasts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
