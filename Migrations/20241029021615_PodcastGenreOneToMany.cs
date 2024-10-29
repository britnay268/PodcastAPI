using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PodcastAPI.Migrations
{
    public partial class PodcastGenreOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PodcastGenres");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Podcasts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Podcasts",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenreId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Podcasts",
                keyColumn: "Id",
                keyValue: 2,
                column: "GenreId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Podcasts",
                keyColumn: "Id",
                keyValue: 3,
                column: "GenreId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Podcasts",
                keyColumn: "Id",
                keyValue: 4,
                column: "GenreId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Podcasts",
                keyColumn: "Id",
                keyValue: 5,
                column: "GenreId",
                value: 7);

            migrationBuilder.CreateIndex(
                name: "IX_Podcasts_GenreId",
                table: "Podcasts",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Podcasts_Genres_GenreId",
                table: "Podcasts",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Podcasts_Genres_GenreId",
                table: "Podcasts");

            migrationBuilder.DropIndex(
                name: "IX_Podcasts_GenreId",
                table: "Podcasts");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Podcasts");

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

            migrationBuilder.CreateIndex(
                name: "IX_PodcastGenres_GenreId",
                table: "PodcastGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastGenres_PodcastId",
                table: "PodcastGenres",
                column: "PodcastId");
        }
    }
}
