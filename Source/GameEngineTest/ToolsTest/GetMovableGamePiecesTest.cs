using GameEngine;
using GameEngine.Assets;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngineTest.ToolsTest
{
    public class GetMovableGamePiecesTest
    {
        [Fact]
        public void Given_4PiecesAtDifferentPositions_DiceIs3_Excpect_ListWith2Pieces()
        {
            //Arrange

            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = 0, Number = 1, TrackPosition = 1},
                new GamePiece(){Color = 0, Number = 2, TrackPosition = 5},
                new GamePiece(){Color = 0, Number = 3, TrackPosition = 7},
                new GamePiece(){Color = 0, Number = 4, TrackPosition = 8}
            };
            GameColor color = 0;
            var diceResult = 3;

            //Act

            var movableGamePieces = Tools.GetMovableGamePieces(gamePieces, color, diceResult);

            //Assert
            Assert.Equal(2, movableGamePieces.Count());
            Assert.Equal(gamePieces[0], movableGamePieces[0]);
            Assert.Equal(gamePieces[3], movableGamePieces[1]);
        }

        [Fact]
        public void Given_4PiecesAtFinalTrack_DiceIs2_Excpect_ListWith0Pieces()
        {
            //Arrange

            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = 0, Number = 1, TrackPosition = 43},
                new GamePiece(){Color = 0, Number = 2, TrackPosition = 42},
                new GamePiece(){Color = 0, Number = 3, TrackPosition = 41},
                new GamePiece(){Color = 0, Number = 4, TrackPosition = 40}
            };
            GameColor color = 0;
            var diceResult = 2;

            //Act

            var movableGamePieces = Tools.GetMovableGamePieces(gamePieces, color, diceResult);

            //Assert
            Assert.Empty(movableGamePieces);
        }

        [Fact]
        public void Given_4PiecesAtFinalTrack_DiceIs1_Excpect_ListWith1Pieces()
        {
            //Arrange

            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = 0, Number = 1, TrackPosition = 43},
                new GamePiece(){Color = 0, Number = 2, TrackPosition = 42},
                new GamePiece(){Color = 0, Number = 3, TrackPosition = 41},
                new GamePiece(){Color = 0, Number = 4, TrackPosition = 40}
            };
            GameColor color = 0;
            var diceResult = 1;

            //Act

            var movableGamePieces = Tools.GetMovableGamePieces(gamePieces, color, diceResult);

            //Assert
            Assert.Single(movableGamePieces);
        }

        [Fact]
        public void Given_4PiecesAtBase_DiceIs6_Excpect_ListWith4Pieces()
        {
            //Arrange

            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = 0, Number = 1, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 2, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 3, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 4, TrackPosition = null}
            };
            GameColor color = 0;
            var diceResult = 6;

            //Act

            var movableGamePieces = Tools.GetMovableGamePieces(gamePieces, color, diceResult);

            //Assert
            Assert.Equal(4, movableGamePieces.Count());
        }

        [Fact]
        public void Given_4PiecesAtBase_DiceIs2_Excpect_ListWith0Pieces()
        {
            //Arrange

            var gamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = 0, Number = 1, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 2, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 3, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 4, TrackPosition = null}
            };
            GameColor color = 0;
            var diceResult = 2;

            //Act

            var movableGamePieces = Tools.GetMovableGamePieces(gamePieces, color, diceResult);

            //Assert
            Assert.Empty(movableGamePieces);
        }
    }
}