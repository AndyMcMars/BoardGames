using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGames.Migrations
{
    /// <inheritdoc />
    public partial class addeditems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mdTournamentId",
                table: "Reviews",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_mdTournamentId",
                table: "Reviews",
                column: "mdTournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Tournaments_mdTournamentId",
                table: "Reviews",
                column: "mdTournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Tournaments_mdTournamentId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_mdTournamentId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "mdTournamentId",
                table: "Reviews");
        }
    }
}
