using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PodcastAPI.Migrations
{
    public partial class AddGenreIdToShowdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "ShowdownResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ShowdownResults",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenreId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShowdownResults",
                keyColumn: "Id",
                keyValue: 2,
                column: "GenreId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShowdownResults",
                keyColumn: "Id",
                keyValue: 3,
                column: "GenreId",
                value: -1);

            migrationBuilder.UpdateData(
                table: "ShowdownResults",
                keyColumn: "Id",
                keyValue: 4,
                column: "GenreId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShowdownResults",
                keyColumn: "Id",
                keyValue: 5,
                column: "GenreId",
                value: -1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "ShowdownResults");
        }
    }
}
