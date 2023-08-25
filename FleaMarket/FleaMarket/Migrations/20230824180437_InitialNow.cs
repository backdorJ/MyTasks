using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleaMarket.Migrations
{
    /// <inheritdoc />
    public partial class InitialNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementsUsers_Recipes_RecipeId",
                table: "AnnouncementsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnnouncementsUsers",
                table: "AnnouncementsUsers");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementsUsers_RecipeId",
                table: "AnnouncementsUsers");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "AnnouncementsUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnnouncementsUsers",
                table: "AnnouncementsUsers",
                columns: new[] { "UserId", "AnnouncementId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnnouncementsUsers",
                table: "AnnouncementsUsers");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "AnnouncementsUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnnouncementsUsers",
                table: "AnnouncementsUsers",
                columns: new[] { "UserId", "AnnouncementId", "RecipeId" });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementsUsers_RecipeId",
                table: "AnnouncementsUsers",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementsUsers_Recipes_RecipeId",
                table: "AnnouncementsUsers",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
