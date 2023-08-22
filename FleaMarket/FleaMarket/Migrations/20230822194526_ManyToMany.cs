using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleaMarket.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnnouncementsUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    AnnouncementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementsUsers", x => new { x.UserId, x.AnnouncementId });
                    table.ForeignKey(
                        name: "FK_AnnouncementsUsers_Announcement_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementsUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementsUsers_AnnouncementId",
                table: "AnnouncementsUsers",
                column: "AnnouncementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementsUsers");
        }
    }
}
