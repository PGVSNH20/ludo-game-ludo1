using Microsoft.EntityFrameworkCore.Migrations;

namespace GameEngine.Migrations
{
    public partial class dbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GamePlayerName",
                table: "Players",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GamePlayerColour",
                table: "Players",
                newName: "Color");

            migrationBuilder.AddColumn<int>(
                name: "GamePlayersId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayersInGame",
                columns: table => new
                {
                    GamePlayersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersInGame", x => x.GamePlayersId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    LudoGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayersGamePlayersId = table.Column<int>(type: "int", nullable: true),
                    WinnerGamePlayerID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextPlayerGamePlayerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.LudoGameId);
                    table.ForeignKey(
                        name: "FK_Games_Players_NextPlayerGamePlayerID",
                        column: x => x.NextPlayerGamePlayerID,
                        principalTable: "Players",
                        principalColumn: "GamePlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_WinnerGamePlayerID",
                        column: x => x.WinnerGamePlayerID,
                        principalTable: "Players",
                        principalColumn: "GamePlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_PlayersInGame_PlayersGamePlayersId",
                        column: x => x.PlayersGamePlayersId,
                        principalTable: "PlayersInGame",
                        principalColumn: "GamePlayersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamePieces",
                columns: table => new
                {
                    GamePieceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TrackPosition = table.Column<int>(type: "int", nullable: true),
                    LudoGameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePieces", x => x.GamePieceId);
                    table.ForeignKey(
                        name: "FK_GamePieces_Games_LudoGameId",
                        column: x => x.LudoGameId,
                        principalTable: "Games",
                        principalColumn: "LudoGameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameMoves",
                columns: table => new
                {
                    GameMoveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerGamePlayerID = table.Column<int>(type: "int", nullable: true),
                    PieceGamePieceId = table.Column<int>(type: "int", nullable: true),
                    OriginalPosition = table.Column<int>(type: "int", nullable: true),
                    DiceThrowResult = table.Column<int>(type: "int", nullable: false),
                    LudoGameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMoves", x => x.GameMoveID);
                    table.ForeignKey(
                        name: "FK_GameMoves_GamePieces_PieceGamePieceId",
                        column: x => x.PieceGamePieceId,
                        principalTable: "GamePieces",
                        principalColumn: "GamePieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameMoves_Games_LudoGameId",
                        column: x => x.LudoGameId,
                        principalTable: "Games",
                        principalColumn: "LudoGameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameMoves_Players_PlayerGamePlayerID",
                        column: x => x.PlayerGamePlayerID,
                        principalTable: "Players",
                        principalColumn: "GamePlayerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_GamePlayersId",
                table: "Players",
                column: "GamePlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMoves_LudoGameId",
                table: "GameMoves",
                column: "LudoGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMoves_PieceGamePieceId",
                table: "GameMoves",
                column: "PieceGamePieceId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMoves_PlayerGamePlayerID",
                table: "GameMoves",
                column: "PlayerGamePlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_GamePieces_LudoGameId",
                table: "GamePieces",
                column: "LudoGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_NextPlayerGamePlayerID",
                table: "Games",
                column: "NextPlayerGamePlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayersGamePlayersId",
                table: "Games",
                column: "PlayersGamePlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerGamePlayerID",
                table: "Games",
                column: "WinnerGamePlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayersInGame_GamePlayersId",
                table: "Players",
                column: "GamePlayersId",
                principalTable: "PlayersInGame",
                principalColumn: "GamePlayersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayersInGame_GamePlayersId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "GameMoves");

            migrationBuilder.DropTable(
                name: "GamePieces");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "PlayersInGame");

            migrationBuilder.DropIndex(
                name: "IX_Players_GamePlayersId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GamePlayersId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "GamePlayerName");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Players",
                newName: "GamePlayerColour");
        }
    }
}
