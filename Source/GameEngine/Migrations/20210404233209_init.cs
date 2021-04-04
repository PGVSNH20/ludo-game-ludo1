using Microsoft.EntityFrameworkCore.Migrations;

namespace GameEngine.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    GamePlayersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => x.GamePlayersId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    GamePlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<int>(type: "int", nullable: false),
                    GamePlayersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.GamePlayerId);
                    table.ForeignKey(
                        name: "FK_Players_GamePlayers_GamePlayersId",
                        column: x => x.GamePlayersId,
                        principalTable: "GamePlayers",
                        principalColumn: "GamePlayersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    LudoGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GamePlayersId = table.Column<int>(type: "int", nullable: true),
                    WinnerGamePlayerId = table.Column<int>(type: "int", nullable: true),
                    NextTurnPlayerGamePlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.LudoGameId);
                    table.ForeignKey(
                        name: "FK_Games_GamePlayers_GamePlayersId",
                        column: x => x.GamePlayersId,
                        principalTable: "GamePlayers",
                        principalColumn: "GamePlayersId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_NextTurnPlayerGamePlayerId",
                        column: x => x.NextTurnPlayerGamePlayerId,
                        principalTable: "Players",
                        principalColumn: "GamePlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_WinnerGamePlayerId",
                        column: x => x.WinnerGamePlayerId,
                        principalTable: "Players",
                        principalColumn: "GamePlayerId",
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
                    Possition = table.Column<int>(type: "int", nullable: true),
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
                name: "Moves",
                columns: table => new
                {
                    GameMoveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerGamePlayerId = table.Column<int>(type: "int", nullable: true),
                    GamePieceId = table.Column<int>(type: "int", nullable: true),
                    OriginalPosition = table.Column<int>(type: "int", nullable: true),
                    DiceThrow = table.Column<int>(type: "int", nullable: false),
                    LudoGameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.GameMoveId);
                    table.ForeignKey(
                        name: "FK_Moves_GamePieces_GamePieceId",
                        column: x => x.GamePieceId,
                        principalTable: "GamePieces",
                        principalColumn: "GamePieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_Games_LudoGameId",
                        column: x => x.LudoGameId,
                        principalTable: "Games",
                        principalColumn: "LudoGameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_Players_PlayerGamePlayerId",
                        column: x => x.PlayerGamePlayerId,
                        principalTable: "Players",
                        principalColumn: "GamePlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePieces_LudoGameId",
                table: "GamePieces",
                column: "LudoGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GamePlayersId",
                table: "Games",
                column: "GamePlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_NextTurnPlayerGamePlayerId",
                table: "Games",
                column: "NextTurnPlayerGamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerGamePlayerId",
                table: "Games",
                column: "WinnerGamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_GamePieceId",
                table: "Moves",
                column: "GamePieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_LudoGameId",
                table: "Moves",
                column: "LudoGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PlayerGamePlayerId",
                table: "Moves",
                column: "PlayerGamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GamePlayersId",
                table: "Players",
                column: "GamePlayersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "GamePieces");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "GamePlayers");
        }
    }
}
