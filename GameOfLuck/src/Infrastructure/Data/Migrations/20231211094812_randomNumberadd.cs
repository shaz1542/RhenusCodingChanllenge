using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOfLuck.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class randomNumberadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "randomNumber",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "randomNumber",
                table: "Games");
        }
    }
}
