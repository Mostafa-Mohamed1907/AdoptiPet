using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptiPet.Migrations
{
    /// <inheritdoc />
    public partial class RenameForignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_ReviewId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Reviews",
                newName: "ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "Reviews",
                newName: "ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_ReviewId",
                table: "Reviews",
                column: "ReviewId",
                principalTable: "Reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
