using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameEngine.Migrations
{
    public partial class DateTimeAndAIPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WinnerGamePlayerID",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "WinnerGamePlayerID",
                table: "Games",
                newName: "WinerGamePlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WinnerGamePlayerID",
                table: "Games",
                newName: "IX_Games_WinerGamePlayerID");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "GameMoves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WinerGamePlayerID",
                table: "Games",
                column: "WinerGamePlayerID",
                principalTable: "Players",
                principalColumn: "GamePlayerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WinerGamePlayerID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameName",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "GameMoves");

            migrationBuilder.RenameColumn(
                name: "WinerGamePlayerID",
                table: "Games",
                newName: "WinnerGamePlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WinerGamePlayerID",
                table: "Games",
                newName: "IX_Games_WinnerGamePlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WinnerGamePlayerID",
                table: "Games",
                column: "WinnerGamePlayerID",
                principalTable: "Players",
                principalColumn: "GamePlayerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
