using GameEngine.Assets;
using GameEngine.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameEngineTestNUnit
{
    internal class GameBoardTest
    {
        [Test]
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

            var board = new GameBoard();

            var expectedOutput =
                $"\r\n" +
                $"               [ ][ ][3]            \r\n" +
                $"      [1][ ]   [ ][ ][ ]   [ ][2]   \r\n" +
                $"      [ ][ ]   [ ][1][3]   [ ][ ]   \r\n" +
                $"               [2][ ][ ]            \r\n" +
                $"   [ ][2][ ][ ][ ][ ][ ][ ][ ][ ][ ]\r\n" +
                $"   [ ][ ][ ][ ][ ]   [1][2][ ][3][ ]\r\n" +
                $"   [ ][ ][ ][ ][ ][4][4][ ][ ][ ][ ]\r\n" +
                $"               [ ][ ][4]            \r\n" +
                $"      [ ][ ]   [ ][ ][ ]   [ ][ ]   \r\n" +
                $"      [ ][ ]   [1][3][ ]   [ ][4]   \r\n" +
                $"               [ ][ ][ ]            \r\n\r\n";

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            board.UpdateTracks(gamePieces);
            board.PrintBoard(gamePieces);

            // Assert
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
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

            var board = new GameBoard();

            var expectedOutput =
                $"\r\n" +
                $"               [ ][ ][ ]            \r\n" +
                $"               [ ][ ][ ]   [1][2]   \r\n" +
                $"               [ ][ ][ ]   [3][4]   \r\n" +
                $"               [ ][ ][ ]            \r\n" +
                $"   [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]\r\n" +
                $"   [ ][ ][ ][ ][ ]   [ ][ ][ ][ ][ ]\r\n" +
                $"   [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]\r\n" +
                $"               [ ][ ][ ]            \r\n" +
                $"      [1][2]   [ ][ ][ ]            \r\n" +
                $"      [3][4]   [ ][ ][ ]            \r\n" +
                $"               [ ][ ][ ]            \r\n\r\n";
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            board.UpdateTracks(gamePieces);
            board.PrintBoard(gamePieces);

            // Assert
            Assert.AreEqual(expectedOutput, output.ToString());
        }
    }
}