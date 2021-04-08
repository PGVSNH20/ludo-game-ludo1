using GameEngine.Assets;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngineTest
{
    public class AIPlayerTest
    {
        [Fact]
        public void Given_1RedPieces_And_1GreenPiecesAtTargetPosition_Expect_True()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = (GameColor)1, Number = 1, TrackPosition = 16},
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 2}
            };

            var board = new GameBoard();
            board.UpdateTracks(gamePieces);

            var dice = new GameDice();
            dice.Result = 6;

            var aiPlayer = new AIPlayer(board, gamePieces, dice);

            board.UpdateTracks(gamePieces);
            // Act

            var gamePieceCanKick = aiPlayer.GamePieceCanKick(gamePieces[0]);

            // Assert
            Assert.True(gamePieceCanKick);
        }

        [Fact]
        public void Given_1RedPieces_And_1GreenPiecesAtNotTargetPosition_Expect_False()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = (GameColor)1, Number = 1, TrackPosition = 16},
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 3}
            };

            var board = new GameBoard();
            board.UpdateTracks(gamePieces);

            var dice = new GameDice();
            dice.Result = 5;

            var aiPlayer = new AIPlayer(board, gamePieces, dice);

            board.UpdateTracks(gamePieces);
            // Act

            var gamePieceCanKick = aiPlayer.GamePieceCanKick(gamePieces[0]);

            // Assert
            Assert.False(gamePieceCanKick);
        }
    }
}