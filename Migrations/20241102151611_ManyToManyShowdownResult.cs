using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PodcastAPI.Migrations
{
    public partial class ManyToManyShowdownResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ShowdownResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ShowdownResults",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShowdownResults",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShowdownResults",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShowdownResults",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShowdownResults",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ShowdownResults_LosingPodcastId",
                table: "ShowdownResults",
                column: "LosingPodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowdownResults_WinningPodcastId",
                table: "ShowdownResults",
                column: "WinningPodcastId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowdownResults_Podcasts_LosingPodcastId",
                table: "ShowdownResults",
                column: "LosingPodcastId",
                principalTable: "Podcasts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowdownResults_Podcasts_WinningPodcastId",
                table: "ShowdownResults",
                column: "WinningPodcastId",
                principalTable: "Podcasts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowdownResults_Podcasts_LosingPodcastId",
                table: "ShowdownResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowdownResults_Podcasts_WinningPodcastId",
                table: "ShowdownResults");

            migrationBuilder.DropIndex(
                name: "IX_ShowdownResults_LosingPodcastId",
                table: "ShowdownResults");

            migrationBuilder.DropIndex(
                name: "IX_ShowdownResults_WinningPodcastId",
                table: "ShowdownResults");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShowdownResults");
        }
    }
}
