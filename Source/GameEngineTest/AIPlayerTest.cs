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
        public void Given_1RedPieces_And_1GreenPiecesAtTargetPosition_Expect_GamePieceCanKickTrue()
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

            var aiPlayer = new GameAI(board, gamePieces, dice);

            board.UpdateTracks(gamePieces);
            // Act

            var gamePieceCanKick = aiPlayer.GamePieceCanKick(gamePieces[0]);

            // Assert
            Assert.True(gamePieceCanKick);
        }

        [Fact]
        public void Given_1RedPieces_And_1GreenPiecesAtNotTargetPosition_Expect_GamePieceCanKickFalse()
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

            var aiPlayer = new GameAI(board, gamePieces, dice);

            board.UpdateTracks(gamePieces);
            // Act

            var gamePieceCanKick = aiPlayer.GamePieceCanKick(gamePieces[0]);

            // Assert
            Assert.False(gamePieceCanKick);
        }

        [Fact]
        public void Given_1RedPiecesAt6_And_1GreenPiecesAt2_Expect_GamePieceIsThreatenedOriginPosTrue()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = (GameColor)1, Number = 1, TrackPosition = 35},
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 12}
            };

            var board = new GameBoard();
            board.UpdateTracks(gamePieces);

            var aiPlayer = new GameAI(board, gamePieces, new GameDice());

            board.UpdateTracks(gamePieces);
            // Act

            var gamePieceIsThreatened = aiPlayer.PieceIsThreatenedAtOriginPos(gamePieces[0]);

            // Assert
            Assert.True(gamePieceIsThreatened);
        }

        [Fact]
        public void Given_1RedPiecesAt8_And_1GreenPiecesAt2_Expect_GamePieceIsThreatenedOriginPosTrue()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = (GameColor)1, Number = 1, TrackPosition = 39},
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 11}
            };

            var board = new GameBoard();
            board.UpdateTracks(gamePieces);

            var aiPlayer = new GameAI(board, gamePieces, new GameDice());

            board.UpdateTracks(gamePieces);
            // Act

            var gamePieceIsThreatened = aiPlayer.PieceIsThreatenedAtOriginPos(gamePieces[0]);

            // Assert
            Assert.False(gamePieceIsThreatened);
        }

        [Fact]
        public void Given_1BluePiecesAt8_And_1GreenPiecesAt2_Expect_GamePieceIsThreatenedAtOriginPosTrue()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = (GameColor)0, Number = 1, TrackPosition = 1}, //1
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 8}  //38
            };

            var board = new GameBoard();
            board.UpdateTracks(gamePieces);

            var dice = new GameDice();
            dice.Result = 2;

            var aiPlayer = new GameAI(board, gamePieces, dice);

            board.UpdateTracks(gamePieces);
            // Act

            var gamePieceIsThreatened = aiPlayer.PieceIsThreatenedAtTargetPos(gamePieces[0]);

            // Assert
            Assert.True(gamePieceIsThreatened);
        }

        [Fact]
        public void Given_1RedPiecesAt6_And_1GreenPiecesAt2_Expect_GamePieceIsThreatenedAtTargetPosTrue()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = (GameColor)1, Number = 1, TrackPosition = 35}, //5
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 12} //2
            };

            var board = new GameBoard();
            board.UpdateTracks(gamePieces);
            var dice = new GameDice();
            dice.Result = 2;
            var aiPlayer = new GameAI(board, gamePieces, dice);

            board.UpdateTracks(gamePieces);
            // Act

            var gamePieceIsThreatened = aiPlayer.PieceIsThreatenedAtOriginPos(gamePieces[0]);

            // Assert
            Assert.True(gamePieceIsThreatened);
        }

        [Fact]
        public void Given_1RedPiecesAt8_And_1GreenPiecesAt2_Expect_GamePieceIsThreatenedTargetPosTrue()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = (GameColor)1, Number = 1, TrackPosition = 39},
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 11}
            };

            var board = new GameBoard();
            board.UpdateTracks(gamePieces);

            var aiPlayer = new GameAI(board, gamePieces, new GameDice());

            board.UpdateTracks(gamePieces);
            // Act

            var gamePieceIsThreatened = aiPlayer.PieceIsThreatenedAtOriginPos(gamePieces[0]);

            // Assert
            Assert.False(gamePieceIsThreatened);
        }

        [Fact]
        public void Given_1BluePiecesAt8_And_1GreenPiecesAt2_Expect_GamePieceIsThreatenedTargetPosTrue()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = (GameColor)0, Number = 1, TrackPosition = 1},
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 8}
            };

            var board = new GameBoard();
            board.UpdateTracks(gamePieces);

            var aiPlayer = new GameAI(board, gamePieces, new GameDice());

            board.UpdateTracks(gamePieces);
            // Act

            var gamePieceIsThreatened = aiPlayer.PieceIsThreatenedAtOriginPos(gamePieces[0]);

            // Assert
            Assert.True(gamePieceIsThreatened);
        }
    }
}