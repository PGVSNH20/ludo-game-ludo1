using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameEngine.Migrations
{
    public partial class GameLastPlayedDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Games",
                newName: "LastPlayed");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "GameMoves",
                newName: "Created");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "LastPlayed",
                table: "Games",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "GameMoves",
                newName: "CreatedTime");
        }
    }
}
