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
        public void Given_AllBlueAndRedAtBase_Expect_CorespontingBoardMap()
        {
            // Arrange
            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = 0, Number = 1, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 2, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 3, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 4, TrackPosition = null},
                new GamePiece(){Color = (GameColor)1, Number = 1, TrackPosition = null},
                new GamePiece(){Color = (GameColor)1, Number = 2, TrackPosition = null},
                new GamePiece(){Color = (GameColor)1, Number = 3, TrackPosition = null},
                new GamePiece(){Color = (GameColor)1, Number = 4, TrackPosition = null}
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

            var expectedBoardString = "hej";
            // Act
            gameRunner.Board.UpdateBoardCells(gamePieces);
            var boardAsString = gameRunner.Board.PrintBoard();

            // Assert
            Assert.Equal(boardAsString, expectedBoardString);
        }
    }
}