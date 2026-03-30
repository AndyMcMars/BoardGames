using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGames.Migrations
{
    /// <inheritdoc />
    public partial class addedpublicidforbetterlinkgeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Matches",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PublicId",
                table: "Matches",
                column: "PublicId",
                unique: true);

            migrationBuilder.Sql(@"
UPDATE Matches
SET PublicId = substr('ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789', abs(random()) % 36 + 1, 8)
WHERE PublicId IS NULL OR PublicId = '';
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matches_PublicId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Matches");
        }
    }
}
