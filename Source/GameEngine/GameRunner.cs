using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameEngine
{
    public class GameRunner
    {
        public LudoGame Game { get; set; }
        public GameDice Dice { get; set; }
        public GameBoard Board { get; set; }
        public AiPlayer Ai { get; set; }

        public GameRunner()
        {
            Game = new LudoGame();
            Dice = new GameDice();
            Board = new GameBoard();
            Ai = new AiPlayer(Board, Game.GamePieceSetUp);
        }

        public GameRunner CreateNewGame()
        {
            Console.WriteLine("Please choose player count");
            int playerCount = int.Parse(Console.ReadLine());
            var availableColors = new List<GameColor>() {
                0, (GameColor)1, (GameColor)2, (GameColor)3,
            };

            for (var i = 1; i <= playerCount; i++)
            {
                Console.Write($"player{i}, write your name: ");
                var playerName = Console.ReadLine();
                playerName = (playerName == string.Empty) ? $"player{i}" : playerName;

                Console.WriteLine($"{playerName}, chose your color: ");

                for (int index = 1; index <= availableColors.Count; index++)
                {
                    Console.WriteLine($"{index}: {availableColors[index - 1]}");
                }
                if (!Int32.TryParse(Console.ReadLine(), out int colorIndex))
                    colorIndex = 1;
                var chosenColor = availableColors[colorIndex - 1];
                availableColors.Remove(chosenColor);
                Game.Players.Add(new Player()
                {
                    Name = playerName,
                    Color = chosenColor,
                });
            }
            Game.Players = Game.Players.OrderBy(p => p.Color).ToList();
            var startingPlayerIndex = new Random().Next(0, Game.Players.Count);
            Game.NextTurnPlayer = Game.Players[startingPlayerIndex];
            //save db
            return this;
        }

        public GameRunner LoadGame()
        {
            Console.WriteLine("You can choose from these games");
            //list from db
            //Game = db....
            return this;
        }

        public GameRunner PlayGame()
        {
            while (Game.Winner == null)
            {
                Console.Clear();
                Board.UppdateBoardTrack();
                Board.UpdateBoardBases(Game.GamePieceSetUp);
                Board.UppdateFinalTracks();
                Board.PrintBoard();
                Console.WriteLine(
                    $"{Game.NextTurnPlayer.Name}'s turn. Whats your move, {Game.NextTurnPlayer.Name}?\n" +
                    $"[1] Throw dice\n" +
                    $"[2] Pause game\n");
                var turnChoise = (Game.NextTurnPlayer.Name.ToLower() == "ai") ? "1" : Console.ReadLine();
                switch ((turnChoise == string.Empty) ? 1 : int.Parse(turnChoise))
                {
                    case 1:
                        ThrowDice();
                        CreateNewGameMove();
                        ChooseGamePiece();
                        if (Game.Moves.Last().GamePiece != null)
                            ExecuteLastMove();
                        else
                            Thread.Sleep(100);
                        SetNextPlayer();
                        break;

                    case 2:
                        //save game
                        break;

                    default:
                        //wrong numer
                        break;
                }
            }
            Console.Clear();
            Board.UppdateBoardTrack();
            Board.UpdateBoardBases(Game.GamePieceSetUp);
            Board.UppdateFinalTracks();
            Board.PrintBoard();
            Console.WriteLine($"Game is finished after {Game.Moves.Count}, the winner is {Game.Winner.Name}");
            return this;
        }

        private void ThrowDice()
        {
            Dice.TrowDice();
            Dice.RenderDiceTrow(Dice.Result);
            Console.WriteLine($"{Game.NextTurnPlayer.Name}, you throw {Dice.Result}");
        }

        public void CreateNewGameMove()
        {
            var gameMove = new GameMove
            {
                Player = Game.NextTurnPlayer,
                //GamePiece = chosenGamePiece,
                //OriginalPosition = chosenGamePiece.Possition,
                DiceThrow = Dice.Result
            };

            //UppdateBoardTrack(gameMove.GamePiece, oldPossition);

            Game.Moves.Add(gameMove);
            //return gameMove
        }

        private void ChooseGamePiece()
        {
            List<GamePiece> availableGamePieces;
            if (Game.Moves.Last().DiceThrow > 1 && Game.Moves.Last().DiceThrow < 6)
                availableGamePieces = Game.GamePieceSetUp.Where(p => (p.Color == Game.NextTurnPlayer.Color && p.Possition != null)).ToList();
            else
                availableGamePieces = Game.GamePieceSetUp.Where(p => p.Color == Game.NextTurnPlayer.Color).ToList();

            availableGamePieces.RemoveAll(p => p.Possition > 44);

            if (availableGamePieces.Count == 0)
            {
                Console.WriteLine("Sorry, you need to throw 1 or 6 to move game piece from base to track");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine($"Which game piece you want to move?");
                foreach (var gamePeace in availableGamePieces)
                {
                    Console.WriteLine($"Game piece number: {gamePeace.Number} currently att position {gamePeace.Possition}");
                }
                var userChoise = (Game.NextTurnPlayer.Name.ToLower() == "ai") ? Ai.ChoosePieceToMove(availableGamePieces) : Console.ReadLine();
                var pieceNumber = (userChoise == string.Empty) ? 1 : int.Parse(userChoise);
                Game.Moves.Last().GamePiece = availableGamePieces
                                                .Find(p =>
                                                    (p.Color == Game.NextTurnPlayer.Color
                                                     && p.Number == pieceNumber));
                Game.Moves.Last().OriginalPosition = Game.Moves.Last().GamePiece.Possition;
            }
        }

        public void ExecuteLastMove()
        {
            var originalPosition = Game.Moves.Last().OriginalPosition;
            var currentGamePiece = Game.Moves.Last().GamePiece;
            var currentGameColor = Game.Moves.Last().Player.Color;
            var newPosition = (originalPosition == null) ? Game.Moves.Last().DiceThrow - 1 : (int)originalPosition + Game.Moves.Last().DiceThrow;
            if (newPosition > 44)
                newPosition = 88 - newPosition;
            //removes game piece from original cell
            if (originalPosition != null && originalPosition < 40)
            {
                var originalBoardTrackCellIndex = (originalPosition + 10 * (int)currentGamePiece.Color) % 40;
                var tmpCell = Board.Track[(int)originalBoardTrackCellIndex];
                //if (originalBoardTrackCell != null) //do we need this?
                tmpCell.Remove(currentGamePiece);
                if (tmpCell.Count == 0)
                    tmpCell = null;
                Board.Track[(int)originalBoardTrackCellIndex] = tmpCell;
            }
            else if (originalPosition >= 40 && originalPosition < 44)
            {
                var tmpCell = Board.FinalTracks[(int)currentGamePiece.Color, (int)originalPosition - 40];
                tmpCell.Remove(currentGamePiece);
                if (tmpCell.Count == 0)
                    tmpCell = null;
                Board.FinalTracks[(int)currentGamePiece.Color, (int)originalPosition - 40] = tmpCell;
            }

            //add game piece to target cell
            if (newPosition < 40)
            {
                var targetBoardTrackCellIndex = ((int)newPosition + 10 * (int)currentGameColor) % 40;
                var tmpCell = Board.Track[targetBoardTrackCellIndex];

                if (tmpCell == null)
                    tmpCell = new List<GamePiece>();
                else
                {
                    if (tmpCell.FindAll(p => p.Color == currentGameColor).Count == 0)
                    {
                        for (int i = 0; i < tmpCell.Count; i++)
                        {
                            tmpCell[i].Possition = null;
                        }
                        tmpCell.Clear();
                    }
                }
                tmpCell.Add(currentGamePiece);
                Board.Track[targetBoardTrackCellIndex] = tmpCell;
            }
            else if (newPosition >= 40 && newPosition < 44)
            {
                var tmpCell = Board.FinalTracks[(int)currentGamePiece.Color, newPosition - 40];
                if (tmpCell == null)
                    tmpCell = new List<GamePiece>();
                tmpCell.Add(currentGamePiece);
                Board.FinalTracks[(int)currentGamePiece.Color, newPosition - 40] = tmpCell;
            }

            currentGamePiece.Possition = newPosition;
            if (newPosition == 44)
            {
                int piecesAtFinish = Game.GamePieceSetUp.Where(p => p.Color == currentGameColor && p.Possition == 44).Count();
                if (piecesAtFinish == 4)
                    Game.Winner = Game.Moves.Last().Player;
            }
            // update database
        }

        private void SetNextPlayer()
        {
            Game.NextTurnPlayer = Game.Players[(Game.Players.IndexOf(Game.NextTurnPlayer) + 1) % Game.Players.Count];
        }
    }
}