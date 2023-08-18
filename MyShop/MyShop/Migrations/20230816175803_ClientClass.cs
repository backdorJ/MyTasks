using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyShop.Migrations
{
    /// <inheritdoc />
    public partial class ClientClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientViewModelId",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientViewModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ClientViewModelId",
                table: "Books",
                column: "ClientViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ClientViewModels_ClientViewModelId",
                table: "Books",
                column: "ClientViewModelId",
                principalTable: "ClientViewModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ClientViewModels_ClientViewModelId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "ClientViewModels");

            migrationBuilder.DropIndex(
                name: "IX_Books_ClientViewModelId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ClientViewModelId",
                table: "Books");
        }
    }
}
