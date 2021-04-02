using GameEngine;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var LudoGame = new GameRunner().CreateNewGame().PlayGame();

            //var players = new List<Player>()
            //{
            //    new Player(){Name = "player1", Color = 0},
            //    new Player(){Name = "player2", Color = (GameColor)1},
            //};
            //var gamePieceSetup = GamePiece.GetGamePeaceSetUp();
            //gamePieceSetup[0] = new GamePiece() { Number = 1, Color = 0, Possition = 14 };
            //gamePieceSetup[4] = new GamePiece() { Number = 1, Color = (GameColor)1, Possition = 5 };
            //gamePieceSetup[5] = new GamePiece() { Number = 2, Color = (GameColor)1, Possition = 5 };

            //var game = new LudoGame()
            //{
            //    Players = players,
            //    GamePeaceSetUp = gamePieceSetup,
            //    NextTurnPlayer = players[0]
            //};

            //var gameMove = new GameMove()
            //{
            //    Player = game.NextTurnPlayer,
            //    GamePiece = gamePieceSetup[0],
            //    OriginalPosition = gamePieceSetup[0].Possition,
            //    DiceThrow = 1
            //};
            //game.Moves.Add(gameMove);

            //var board = new GameBoard();
            //board.Track[14] = new List<GamePiece>() { gamePieceSetup[0] };
            //board.Track[15] = new List<GamePiece>() { gamePieceSetup[4], gamePieceSetup[5] };
            //var gameRunner = new GameRunner()
            //{
            //    Game = game,
            //    Board = board
            //};
            //gameRunner.Board.UppdateBoardTrack();
            //gameRunner.Board.UpdateBoardBases(game.GamePeaceSetUp);
            //gameRunner.Board.UppdateFinalTracks();
            //gameRunner.Board.PrintBoard();

            //gameRunner.ExecuteLastMove();

            //gameRunner.Board.UppdateBoardTrack();
            //gameRunner.Board.UpdateBoardBases(game.GamePeaceSetUp);
            //gameRunner.Board.UppdateFinalTracks();
            //gameRunner.Board.PrintBoard();

            //var pieces = gameRunner.Game.GamePeaceSetUp.Where(p => p.Color == (GameColor)1);
        }
    }
}