using GameEngine;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameEngineTest
{
    public class GameEngineTest
    {
        [Fact]
        public void When_GamePieceTargetsCellWithTwoOpenentGamePiecesOn_Expect_OpentsPiecesBePlacedAtBase()
        {
            var gamePlayers = new GamePlayers();

            gamePlayers.Players.Add(new GamePlayer() { Name = "player1", Color = 0 });
            gamePlayers.Players.Add(new GamePlayer() { Name = "player2", Color = (GameColor)1 });

            var gamePieceSetup = GamePiece.GetGamePeaceSetUp();
            gamePieceSetup[0] = new GamePiece() { Number = 1, Color = 0, Possition = 14 };
            gamePieceSetup[4] = new GamePiece() { Number = 1, Color = (GameColor)1, Possition = 5 };
            gamePieceSetup[5] = new GamePiece() { Number = 2, Color = (GameColor)1, Possition = 5 };

            var game = new LudoGame()
            {
                GamePlayers = gamePlayers,
                GamePieceSetUp = gamePieceSetup,
                NextTurnPlayer = gamePlayers.Players[0]
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
            var gamePlayers = new GamePlayers();
            gamePlayers.Players.Add(new GamePlayer() { Name = "player1", Color = 0 });

            var gamePieceSetup = GamePiece.GetGamePeaceSetUp();
            gamePieceSetup[0] = new GamePiece() { Number = 1, Color = 0, Possition = 5 };

            var game = new LudoGame()
            {
                GamePlayers = gamePlayers,
                GamePieceSetUp = gamePieceSetup,
                NextTurnPlayer = gamePlayers.Players[0]
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
            var gamePlayers = new GamePlayers();
            gamePlayers.Players.Add(new GamePlayer() { Name = "player1", Color = 0 });

            var gamePieceSetup = GamePiece.GetGamePeaceSetUp();
            gamePieceSetup[0] = new GamePiece() { Number = 1, Color = 0, Possition = 5 };

            var game = new LudoGame()
            {
                GamePlayers = gamePlayers,
                GamePieceSetUp = gamePieceSetup,
                NextTurnPlayer = gamePlayers.Players[0]
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

        [Fact]
        public void When_GamePieceOfSameColorReachFinish_SetPlayerAsWinner()
        {
            var gamePlayers = new GamePlayers();
            gamePlayers.Players.Add(new GamePlayer() { Name = "player1", Color = 0 });

            var gamePieceSetup = GamePiece.GetGamePeaceSetUp();
            gamePieceSetup[0] = new GamePiece() { Number = 1, Color = 0, Possition = 38 };
            gamePieceSetup[1] = new GamePiece() { Number = 2, Color = 0, Possition = 42 };
            gamePieceSetup[2] = new GamePiece() { Number = 3, Color = 0, Possition = 43 };
            gamePieceSetup[3] = new GamePiece() { Number = 4, Color = 0, Possition = 43 };

            var game = new LudoGame()
            {
                GamePlayers = gamePlayers,
                GamePieceSetUp = gamePieceSetup,
                NextTurnPlayer = gamePlayers.Players[0]
            };
            var board = new GameBoard();
            board.Track[38] = new List<GamePiece>() { gamePieceSetup[0] };
            board.FinalTracks[0, 2] = new List<GamePiece>() { gamePieceSetup[1] };
            board.FinalTracks[0, 3] = new List<GamePiece>() { gamePieceSetup[2] };
            board.FinalTracks[0, 3] = new List<GamePiece>() { gamePieceSetup[3] };

            var gameRunner = new GameRunner()
            {
                Game = game,
                Board = board
            };
            var gameMove1 = new GameMove()
            {
                Player = game.NextTurnPlayer,
                GamePiece = gamePieceSetup[0],
                OriginalPosition = gamePieceSetup[0].Possition,
                DiceThrow = 6
            };

            game.Moves.Add(gameMove1);
            gameRunner.ExecuteLastMove();

            var gameMove2 = new GameMove()
            {
                Player = game.NextTurnPlayer,
                GamePiece = gamePieceSetup[1],
                OriginalPosition = gamePieceSetup[1].Possition,
                DiceThrow = 2
            };
            game.Moves.Add(gameMove2);
            gameRunner.ExecuteLastMove();

            var gameMove3 = new GameMove()
            {
                Player = game.NextTurnPlayer,
                GamePiece = gamePieceSetup[2],
                OriginalPosition = gamePieceSetup[2].Possition,
                DiceThrow = 1
            };
            game.Moves.Add(gameMove3);
            gameRunner.ExecuteLastMove();

            var gameMove4 = new GameMove()
            {
                Player = game.NextTurnPlayer,
                GamePiece = gamePieceSetup[3],
                OriginalPosition = gamePieceSetup[3].Possition,
                DiceThrow = 1
            };
            game.Moves.Add(gameMove4);
            gameRunner.ExecuteLastMove();

            var pieces = gameRunner.Game.GamePieceSetUp.Where(p => p.Color == (GameColor)1);
            var winner = gameRunner.Game.Winner;
            var player = gameRunner.Game.GamePlayers.Players[0];

            Assert.Equal(winner, player);
            Assert.Null(board.Track[38]);
            Assert.Null(board.FinalTracks[0, 2]);
            Assert.Null(board.FinalTracks[0, 3]);
        }
    }
}