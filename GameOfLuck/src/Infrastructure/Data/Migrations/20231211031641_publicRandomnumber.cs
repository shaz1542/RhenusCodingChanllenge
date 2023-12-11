using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOfLuck.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class publicRandomnumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Players",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "name");

            migrationBuilder.AlterColumn<int>(
                name: "name",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
