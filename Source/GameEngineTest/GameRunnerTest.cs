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
        public void Given_NextTurnGreen_And_GreenAtPos8_DiceIs5_Expect_Track38IsNull_And_Track3IsGreen()
        {
            //Arrange
            var gamePiece = new GamePiece() { Color = (GameColor)3, TrackPosition = 8 };
            var gamePlayer = new GamePlayer() { Color = (GameColor)3 };
            var diceThrowResult = 5;

            var gameMove = new GameMove()
            {
                Player = gamePlayer,
                Piece = gamePiece,
                OriginalPosition = gamePiece.TrackPosition,
                DiceThrowResult = diceThrowResult
            };

            var board = new GameBoard();
            board.MainTrack[38] = gameMove.Piece;

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

            Assert.Null(board.MainTrack[38]);
            Assert.Equal((GameColor)3, board.MainTrack[3].Color);
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
    }
}