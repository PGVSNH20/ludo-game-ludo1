using Microsoft.EntityFrameworkCore.Migrations;

namespace GameEngine.Migrations
{
    public partial class changingGamePlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_PlayersInGame_PlayersGamePlayersId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PlayersGamePlayersId",
                table: "Games",
                newName: "GamePlayersId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PlayersGamePlayersId",
                table: "Games",
                newName: "IX_Games_GamePlayersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_PlayersInGame_GamePlayersId",
                table: "Games",
                column: "GamePlayersId",
                principalTable: "PlayersInGame",
                principalColumn: "GamePlayersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_PlayersInGame_GamePlayersId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GamePlayersId",
                table: "Games",
                newName: "PlayersGamePlayersId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_GamePlayersId",
                table: "Games",
                newName: "IX_Games_PlayersGamePlayersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_PlayersInGame_PlayersGamePlayersId",
                table: "Games",
                column: "PlayersGamePlayersId",
                principalTable: "PlayersInGame",
                principalColumn: "GamePlayersId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
