using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleaMarket.Migrations
{
    /// <inheritdoc />
    public partial class AddedCountSimilarFavourite2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "AnnouncementsUsers");

            migrationBuilder.DropColumn(
                name: "CountItem",
                table: "Announcement");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "AnnouncementsUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "AnnouncementsUsers");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "AnnouncementsUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountItem",
                table: "Announcement",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
