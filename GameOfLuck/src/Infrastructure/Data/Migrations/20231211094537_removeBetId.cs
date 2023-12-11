using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOfLuck.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeBetId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "randomNumber",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "BetId",
                table: "Bets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "randomNumber",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BetId",
                table: "Bets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
