using GameEngine;
using GameEngine.Assets;
using GameEngine.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameEngineTestNUnit.InputDialogsTest
{
    internal class GetGamePieceToMoveTest
    {
        private List<GamePiece> GamePieces { get; set; }

        [SetUp]
        public void ArrangeSetUp()
        {
            GamePieces = new List<GamePiece>()
            {
                new GamePiece(){Color = 0, Number = 1, TrackPosition = null},
                new GamePiece(){Color = 0, Number = 2, TrackPosition = 7},
                new GamePiece(){Color = 0, Number = 3, TrackPosition = 9},
                new GamePiece(){Color = 0, Number = 4, TrackPosition = 15},
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
        }

        [Test]
        public void Given_Options_Expect_3PiecToChose_and_1Chosen()
        {
            var color = (GameColor)3;
            var diceResult = 1;

            var input = new StringReader("1");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var expectedOutput =
                $"Choose your game piece:\r\n" +
                $"1) Piece number: 1 at position 44\r\n" +
                $"2) Piece number: 3 at position 41\r\n" +
                $"3) Piece number: 4 at base\r\n";

            var gamePiece = InputDialogs.GetGamePieceToMove(GamePieces, color, diceResult);
            Assert.AreEqual(expectedOutput, output.ToString());
            Assert.AreEqual(GamePieces[12], gamePiece);
        }

        [Test]
        public void Given_Options_2PiecToChose_and_1Chosen()
        {
            var color = (GameColor)0;
            var diceResult = 6;

            var input = new StringReader("2");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var expectedOutput =
                $"Choose your game piece:\r\n" +
                $"1) Piece number: 1 at base\r\n" +
                $"2) Piece number: 4 at position 16\r\n";

            var gamePiece = InputDialogs.GetGamePieceToMove(GamePieces, color, diceResult);
            Assert.AreEqual(expectedOutput, output.ToString());
            Assert.AreEqual(GamePieces[3], gamePiece);
        }
    }
}