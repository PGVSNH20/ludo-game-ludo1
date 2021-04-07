using GameEngine;
using GameEngine.Assets;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngineTest
{
    public class GameRunnerTest
    {
        [Fact]
        public void Given_NextTurnBlue_BlueAtPos10_DiceResult5_Expect_BlueAtPos15()
        {
            //Arrange
            var gamePiece = new GamePiece() { Color = 0, TrackPosition = 10 };
            var gamePlayer = new GamePlayer() { Color = 0 };
            var diceThrowResult = 5;
            var board = new GameBoard();
            var game = new LudoGame();

            var gameMove = new GameMove()
            {
                Player = gamePlayer,
                Piece = gamePiece,
                OriginalPosition = gamePiece.TrackPosition,
                DiceThrowResult = diceThrowResult
            };
            game.Moves.Add(gameMove);

            var gameRunner = new GameRunner()
            {
                Game = game,
                Board = board
            };

            //Act

            gameRunner.ExecuteMove();

            //Assert

            Assert.Equal(15, gamePiece.TrackPosition);
        }

        [Fact]
        public void Given_NextTurnBlue_And_BlueAtPos10_DiceIs5_Expect_Track10IsNull_And_Track15IsBlue()
        {
            //Arrange
            var gamePiece = new GamePiece() { Color = 0, TrackPosition = 10 };
            var gamePlayer = new GamePlayer() { Color = 0 };
            var diceThrowResult = 5;

            var gameMove = new GameMove()
            {
                Player = gamePlayer,
                Piece = gamePiece,
                OriginalPosition = gamePiece.TrackPosition,
                DiceThrowResult = diceThrowResult
            };

            var board = new GameBoard();
            board.MainTrack[10] = gameMove.Piece;

            var game = new LudoGame();
            game.Moves.Add(gameMove);

            var gameRunner = new GameRunner()
            {
                Game = game,
                Board = board
            };

            //Act

            gameRunner.ExecuteMove();

            //Assert

            Assert.Null(board.MainTrack[10]);
            Assert.Equal((GameColor)0, board.MainTrack[15].Color);
        }

        [Fact]
        public void Given_NextTurnBlue_And_BlueAtPos10_And_RedAtPos15_DiceResult5_Expect_BlueAtPos15_And_RedAtPosNull()
        {
            //Arrange
            var gamePieceBlue = new GamePiece() { Color = 0, TrackPosition = 10 };
            var gamePieceRed = new GamePiece() { Color = (GameColor)1, TrackPosition = 15 };
            var gamePlayer = new GamePlayer() { Color = 0 };
            var diceThrowResult = 5;

            var gameMove = new GameMove()
            {
                Player = gamePlayer,
                Piece = gamePieceBlue,
                OriginalPosition = gamePieceBlue.TrackPosition,
                DiceThrowResult = diceThrowResult
            };

            var board = new GameBoard();
            board.MainTrack[10] = gamePieceBlue;
            board.MainTrack[15] = gamePieceRed;

            var game = new LudoGame()
            {
                PieceSetup = new List<GamePiece>()
            };
            game.PieceSetup.Add(gamePieceBlue);
            game.PieceSetup.Add(gamePieceRed);

            game.Moves.Add(gameMove);

            var gameRunner = new GameRunner()
            {
                Game = game,
                Board = board
            };

            //Act

            gameRunner.ExecuteMove();

            //Assert
            Assert.Null(gamePieceRed.TrackPosition);
            Assert.Equal((GameColor)0, board.MainTrack[15].Color);
        }

        [Fact]
        public void Given_NextTurnBlue_And_BlueAtPos43_DiceIs6_Expect_BlueAtPos39()
        {
            //Arrange
            var gamePiece = new GamePiece() { Color = 0, TrackPosition = 43 };
            var gamePlayer = new GamePlayer() { Color = 0 };
            var diceThrowResult = 6;
            var board = new GameBoard();
            var game = new LudoGame();

            var gameMove = new GameMove()
            {
                Player = gamePlayer,
                Piece = gamePiece,
                OriginalPosition = gamePiece.TrackPosition,
                DiceThrowResult = diceThrowResult
            };
            game.Moves.Add(gameMove);

            var gameRunner = new GameRunner()
            {
                Game = game,
                Board = board
            };

            //Act

            gameRunner.ExecuteMove();

            //Assert

            Assert.Equal(39, gamePiece.TrackPosition);
        }

        //[Fact]
        //public void Given_InputForNewGameWith4Players_Excpect_NewGameWith4Players()
        //{
        //    //Arrange

        //    var gameRunner = new GameRunner();
        //    var playerAmount = 4;
        //    var players = new List<string>() { "Bob", "Rob", "Bil", "Ted" };
        //    var colors = new List<string>() { "3", "1", "2", "1" };

        //    //Act

        //    gameRunner.CreateNewGame();
        //    var input = new StringReader(playerAmount.ToString());
        //    Console.SetIn(input);
        //    for (int i = 0; i < 4; i++)
        //    {
        //        input = new StringReader(players[i]);
        //        Console.SetIn(input);
        //        input = new StringReader(colors[i]);
        //        Console.SetIn(input);
        //    }

        //    //Assert
        //    Assert.Equal(4, gameRunner.Game.Players.Count);
        //}

        //public static void Test(string[] args)
        //{
        //    Console.WriteLine("What's your name?");
        //    var name = Console.ReadLine();
        //    Console.WriteLine(string.Format("Hello {0}!!", name));
        //}

        //[Test]
        //public void something()
        //{
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("Somebody");
        //    Console.SetIn(input);

        //    Program.Main(new string[] { });

        //    Assert.That(output.ToString(), Is.EqualTo(string.Format("What's your name?{0}Hello Somebody!!{0}", Environment.NewLine)));
    }
}