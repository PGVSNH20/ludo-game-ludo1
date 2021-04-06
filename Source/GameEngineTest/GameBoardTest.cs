using GameEngine;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngineTest
{
    public class GameBoardTest
    {
        [Fact]
        public void Given_AllColorGamePiecesSpreadOnBoard_Expect_CorespontingBoardMap()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = 0, Number = 1, TrackPosition = 1},
                new GamePiece(){Color = 0, Number = 2, TrackPosition = 15},
                new GamePiece(){Color = 0, Number = 3, TrackPosition = 40},
                new GamePiece(){Color = 0, Number = 4, TrackPosition = 43},
                new GamePiece(){Color = (GameColor)1, Number = 1, TrackPosition = null},
                new GamePiece(){Color = (GameColor)1, Number = 2, TrackPosition = 1},
                new GamePiece(){Color = (GameColor)1, Number = 3, TrackPosition = 10},
                new GamePiece(){Color = (GameColor)1, Number = 4, TrackPosition = 25},
                new GamePiece(){Color = (GameColor)2, Number = 1, TrackPosition = 41},
                new GamePiece(){Color = (GameColor)2, Number = 2, TrackPosition = null},
                new GamePiece(){Color = (GameColor)2, Number = 3, TrackPosition = 2},
                new GamePiece(){Color = (GameColor)2, Number = 4, TrackPosition = 14},
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 43},
                new GamePiece(){Color = (GameColor)3, Number = 2, TrackPosition = 42},
                new GamePiece(){Color = (GameColor)3, Number = 3, TrackPosition = 40},
                new GamePiece(){Color = (GameColor)3, Number = 4, TrackPosition = null}
            };
            var game = new LudoGame()
            {
                PieceSetup = gamePieces,
            };
            var gameRunner = new GameRunner()
            {
                Game = game,
                Board = new GameBoard()
            };

            var expectedBoardString =
                $"\n" +
                $"               [ ][ ][3]            \n" +
                $"      [1][ ]   [ ][ ][ ]   [ ][2]   \n" +
                $"      [ ][ ]   [ ][1][3]   [ ][ ]   \n" +
                $"               [2][ ][ ]            \n" +
                $"   [ ][2][ ][ ][ ][ ][ ][ ][ ][ ][ ]\n" +
                $"   [ ][ ][ ][ ][ ]   [1][2][ ][3][ ]\n" +
                $"   [ ][ ][ ][ ][ ][4][4][ ][ ][ ][ ]\n" +
                $"               [ ][ ][4]            \n" +
                $"      [ ][ ]   [ ][ ][ ]   [ ][ ]   \n" +
                $"      [ ][ ]   [1][3][ ]   [ ][4]   \n" +
                $"               [ ][ ][ ]            \n\n";
            // Act

            gameRunner.Board.UpdateTracks(gamePieces);
            var boardAsString = gameRunner.Board.PrintBoard(gamePieces);

            // Assert
            Assert.Equal(expectedBoardString, boardAsString);
        }

        [Fact]
        public void Given_AllBlueAndYellowAtBase_Expect_CorespontingBoardMap()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = 0, Number = 1, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 2, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 3, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 4, TrackPosition = null},
                new GamePiece(){Color = (GameColor)2, Number = 1, TrackPosition = null},
                new GamePiece(){Color = (GameColor)2, Number = 2, TrackPosition = null},
                new GamePiece(){Color = (GameColor)2, Number = 3, TrackPosition = null},
                new GamePiece(){Color = (GameColor)2, Number = 4, TrackPosition = null}
            };
            var game = new LudoGame()
            {
                PieceSetup = gamePieces,
            };
            var gameRunner = new GameRunner()
            {
                Game = game,
                Board = new GameBoard()
            };

            var expectedBoardString =
                $"\n" +
                $"               [ ][ ][ ]            \n" +
                $"               [ ][ ][ ]   [1][2]   \n" +
                $"               [ ][ ][ ]   [3][4]   \n" +
                $"               [ ][ ][ ]            \n" +
                $"   [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]\n" +
                $"   [ ][ ][ ][ ][ ]   [ ][ ][ ][ ][ ]\n" +
                $"   [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]\n" +
                $"               [ ][ ][ ]            \n" +
                $"      [1][2]   [ ][ ][ ]            \n" +
                $"      [3][4]   [ ][ ][ ]            \n" +
                $"               [ ][ ][ ]            \n\n";
            // Act
            gameRunner.Board.UpdateTracks(gamePieces);
            var boardAsString = gameRunner.Board.PrintBoard(gamePieces);

            // Assert
            Assert.Equal(boardAsString, expectedBoardString);
        }
    }
}