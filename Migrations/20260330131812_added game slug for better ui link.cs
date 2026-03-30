using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGames.Migrations
{
    /// <inheritdoc />
    public partial class addedgameslugforbetteruilink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Games",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Games");
        }
    }
}
