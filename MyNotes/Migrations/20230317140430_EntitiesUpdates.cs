using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNotes.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_userId1",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_userId1",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "Notes");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_userId",
                table: "Notes",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_userId",
                table: "Notes",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_userId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_userId",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "Notes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_userId1",
                table: "Notes",
                column: "userId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_userId1",
                table: "Notes",
                column: "userId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
