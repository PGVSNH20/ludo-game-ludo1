using GameEngine;
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

            var board = new GameBoard();

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

            board.UpdateTracks(gamePieces);
            var boardAsString = board.PrintBoard(gamePieces);

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

            var board = new GameBoard();

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
            board.UpdateTracks(gamePieces);
            var boardAsString = board.PrintBoard(gamePieces);

            // Assert
            Assert.Equal(boardAsString, expectedBoardString);
        }

        [Fact]
        public void Given_GamePieceSetup_Expect_CorespondingTracks()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = 0, Number = 1, TrackPosition = 1}, //0
                new GamePiece(){Color = 0, Number = 2, TrackPosition = 15}, //1
                new GamePiece(){Color = 0, Number = 3, TrackPosition = 40}, //2
                new GamePiece(){Color = 0, Number = 4, TrackPosition = 43}, //3
                new GamePiece(){Color = (GameColor)1, Number = 1, TrackPosition = null}, //4
                new GamePiece(){Color = (GameColor)1, Number = 2, TrackPosition = 1}, //5
                new GamePiece(){Color = (GameColor)1, Number = 3, TrackPosition = 10}, //6
                new GamePiece(){Color = (GameColor)1, Number = 4, TrackPosition = 25}, //7
                new GamePiece(){Color = (GameColor)2, Number = 1, TrackPosition = 41}, //8
                new GamePiece(){Color = (GameColor)2, Number = 2, TrackPosition = null}, //9
                new GamePiece(){Color = (GameColor)2, Number = 3, TrackPosition = 2}, //10
                new GamePiece(){Color = (GameColor)2, Number = 4, TrackPosition = 14}, //11
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 43}, //12
                new GamePiece(){Color = (GameColor)3, Number = 2, TrackPosition = 42}, //13
                new GamePiece(){Color = (GameColor)3, Number = 3, TrackPosition = 40}, //14
                new GamePiece(){Color = (GameColor)3, Number = 4, TrackPosition = null} //15
            };

            var board = new GameBoard();

            // Act
            board.UpdateTracks(gamePieces);

            //Assert
            Assert.Equal(gamePieces[0], board.MainTrack[1]);
            Assert.Equal(gamePieces[1], board.MainTrack[15]);
            Assert.Equal(gamePieces[2], board.FinalTracks[0][0]);
            Assert.Equal(gamePieces[3], board.FinalTracks[0][3]);
            Assert.Equal(gamePieces[5], board.MainTrack[11]);
            Assert.Equal(gamePieces[6], board.MainTrack[20]);
            Assert.Equal(gamePieces[7], board.MainTrack[35]);
            Assert.Equal(gamePieces[8], board.FinalTracks[2][1]);
            Assert.Equal(gamePieces[10], board.MainTrack[22]);
            Assert.Equal(gamePieces[11], board.MainTrack[34]);
            Assert.Equal(gamePieces[12], board.FinalTracks[3][3]);
            Assert.Equal(gamePieces[13], board.FinalTracks[3][2]);
            Assert.Equal(gamePieces[14], board.FinalTracks[3][0]);
        }
        [Fact]
        public void Given_GamePieceSetupWith2Pieces_Expect_CorespondingTracks()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = (GameColor)1, Number = 1, TrackPosition = 35},
                new GamePiece(){Color = (GameColor)3, Number = 1, TrackPosition = 12}
            };

            var board = new GameBoard();

            // Act
            board.UpdateTracks(gamePieces);

            //Assert
            Assert.Equal(gamePieces[0], board.MainTrack[5]);
            Assert.Equal(gamePieces[1], board.MainTrack[2]);
        }
    }
}