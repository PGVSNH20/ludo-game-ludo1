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
    public class GameRunnerTest
    {
        [Fact]
        public void Given_NextTurnBlue_BlueAtPos10_DiceResult5_Expect_BlueAtPos15()
        {
            //Arrange
            var gamePiece = new GamePiece() { Color = 0, TrackPosition = 10 };
            var gamePlayer = new GamePlayer() { GamePlayerColour = 0 };
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

            gameRunner.ExecuteLastMove();

            //Assert

            Assert.Equal(15, gamePiece.TrackPosition);
        }

        [Fact]
        public void Given_NextTurnBlue_And_BlueAtPos10_DiceIs5_Expect_Track10IsNull_And_Track15IsBlue()
        {
            //Arrange
            var gamePiece = new GamePiece() { Color = 0, TrackPosition = 10 };
            var gamePlayer = new GamePlayer() { GamePlayerColour = 0 };
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

            gameRunner.ExecuteLastMove();

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
            var gamePlayer = new GamePlayer() { GamePlayerColour = 0 };
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

            gameRunner.ExecuteLastMove();

            //Assert
            Assert.Null(gamePieceRed.TrackPosition);
            Assert.Equal((GameColor)0, board.MainTrack[15].Color);
        }

        [Fact]
        public void Given_NextTurnBlue_And_BlueAtPos43_DiceIs6_Expect_BlueAtPos39()
        {
            //Arrange
            var gamePiece = new GamePiece() { Color = 0, TrackPosition = 43 };
            var gamePlayer = new GamePlayer() { GamePlayerColour = 0 };
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

            gameRunner.ExecuteLastMove();

            //Assert

            Assert.Equal(39, gamePiece.TrackPosition);
        }

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
            var gamePlayer = new GamePlayer() { GamePlayerColour = 0 };
            var gameDice = new GameDice() { LastResult = 3 };
            var game = new LudoGame()
            {
                PieceSetup = gamePieces,
                NextTurnPlayer = gamePlayer,
            };

            var gameRunner = new GameRunner()
            {
                Game = game,
                Dice = gameDice
            };

            //Act

            var movableGamePieces = gameRunner.GetMovableGamePieces();

            //Assert
            Assert.Equal(2, movableGamePieces.Count());
            Assert.Equal(gamePieces[0], movableGamePieces[0]);
            Assert.Equal(gamePieces[3], movableGamePieces[1]);
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
            var gamePlayer = new GamePlayer() { GamePlayerColour = 0 };
            var gameDice = new GameDice() { LastResult = 6 };
            var game = new LudoGame()
            {
                PieceSetup = gamePieces,
                NextTurnPlayer = gamePlayer,
            };

            var gameRunner = new GameRunner()
            {
                Game = game,
                Dice = gameDice
            };

            //Act

            var movableGamePieces = gameRunner.GetMovableGamePieces();

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
            var gamePlayer = new GamePlayer() { GamePlayerColour = 0 };
            var gameDice = new GameDice() { LastResult = 2 };
            var game = new LudoGame()
            {
                PieceSetup = gamePieces,
                NextTurnPlayer = gamePlayer,
            };

            var gameRunner = new GameRunner()
            {
                Game = game,
                Dice = gameDice
            };

            //Act

            var movableGamePieces = gameRunner.GetMovableGamePieces();

            //Assert
            Assert.Empty(movableGamePieces);
        }
    }
}