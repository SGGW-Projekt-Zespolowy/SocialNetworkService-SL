using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostBookmarks_Users_UserId",
                table: "PostBookmarks");

            migrationBuilder.AddForeignKey(
                name: "FK_PostBookmarks_Users_UserId",
                table: "PostBookmarks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostBookmarks_Users_UserId",
                table: "PostBookmarks");

            migrationBuilder.AddForeignKey(
                name: "FK_PostBookmarks_Users_UserId",
                table: "PostBookmarks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
