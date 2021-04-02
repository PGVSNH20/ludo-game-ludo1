using GameEngine;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameEngineTest
{
    public class UnitTest1
    {
        [Fact]
        public void When_GamePieceTargetsCellWithTwoOpenentGamePiecesOn_Expect_OpentsPiecesBePlacedAtBase()
        {
            var players = new List<Player>()
            {
                new Player(){Name = "player1", Color = 0},
                new Player(){Name = "player2", Color = (GameColor)1},
            };
            var gamePieceSetup = GamePiece.GetGamePeaceSetUp();
            gamePieceSetup[0] = new GamePiece() { Number = 1, Color = 0, Possition = 14 };
            gamePieceSetup[4] = new GamePiece() { Number = 1, Color = (GameColor)1, Possition = 5 };
            gamePieceSetup[5] = new GamePiece() { Number = 2, Color = (GameColor)1, Possition = 5 };

            var game = new LudoGame()
            {
                Players = players,
                GamePieceSetUp = gamePieceSetup,
                NextTurnPlayer = players[0]
            };

            var gameMove = new GameMove()
            {
                Player = game.NextTurnPlayer,
                GamePiece = gamePieceSetup[0],
                OriginalPosition = gamePieceSetup[0].Possition,
                DiceThrow = 1
            };
            game.Moves.Add(gameMove);

            var board = new GameBoard();
            board.Track[14] = new List<GamePiece>() { gamePieceSetup[0] };
            board.Track[15] = new List<GamePiece>() { gamePieceSetup[4], gamePieceSetup[5] };
            var gameRunner = new GameRunner()
            {
                Game = game,
                Board = board
            };

            gameRunner.ExecuteLastMove();

            var pieces = gameRunner.Game.GamePieceSetUp.Where(p => p.Color == (GameColor)1);

            Assert.Collection(pieces,
                piece => Assert.Null(piece.Possition),
                piece => Assert.Null(piece.Possition),
                piece => Assert.Null(piece.Possition),
                piece => Assert.Null(piece.Possition));
        }

        [Fact]
        public void When_GamePieceTargetsNewCell_ThatGamePiecePosstionIsChanged()
        {
            var players = new List<Player>()
            {
                new Player(){Name = "player1", Color = 0}
            };
            var gamePieceSetup = GamePiece.GetGamePeaceSetUp();
            gamePieceSetup[0] = new GamePiece() { Number = 1, Color = 0, Possition = 5 };

            var game = new LudoGame()
            {
                Players = players,
                GamePieceSetUp = gamePieceSetup,
                NextTurnPlayer = players[0]
            };

            var gameMove = new GameMove()
            {
                Player = game.NextTurnPlayer,
                GamePiece = gamePieceSetup[0],
                OriginalPosition = gamePieceSetup[0].Possition,
                DiceThrow = 1
            };
            game.Moves.Add(gameMove);

            var board = new GameBoard();
            board.Track[5] = new List<GamePiece>() { gamePieceSetup[0] };
            var gameRunner = new GameRunner()
            {
                Game = game,
                Board = board
            };

            gameRunner.ExecuteLastMove();

            var piece = gameRunner.Game.GamePieceSetUp[0];

            Assert.Equal(6, piece.Possition);
        }

        [Fact]
        public void When_GamePieceTargetsNewCell_TrackCellContentIsChanged()
        {
            var players = new List<Player>()
            {
                new Player(){Name = "player1", Color = 0}
            };
            var gamePieceSetup = GamePiece.GetGamePeaceSetUp();
            gamePieceSetup[0] = new GamePiece() { Number = 1, Color = 0, Possition = 5 };

            var game = new LudoGame()
            {
                Players = players,
                GamePieceSetUp = gamePieceSetup,
                NextTurnPlayer = players[0]
            };

            var gameMove = new GameMove()
            {
                Player = game.NextTurnPlayer,
                GamePiece = gamePieceSetup[0],
                OriginalPosition = gamePieceSetup[0].Possition,
                DiceThrow = 1
            };
            game.Moves.Add(gameMove);

            var board = new GameBoard();
            board.Track[5] = new List<GamePiece>() { gamePieceSetup[0] };
            var gameRunner = new GameRunner()
            {
                Game = game,
                Board = board
            };

            gameRunner.ExecuteLastMove();

            var originalTrackCell = board.Track[5];
            var targetTrackCell = board.Track[6];

            Assert.Null(originalTrackCell);
            Assert.NotNull(targetTrackCell);
        }
    }
}