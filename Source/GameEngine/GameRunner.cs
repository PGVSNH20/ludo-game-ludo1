using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class GameRunner
    {
        public LudoGame Game { get; set; }
        public GameDice Dice { get; set; }
        public GameBoard Board { get; set; }

        public GameRunner()
        {
            Dice = new GameDice();
            Board = new GameBoard();
        }

        public void CreateNewGame()
        {
            // Player chooses amount of players
            int playerAmmount = GetPlayerAmount();

            Game = new LudoGame();

            Game.Players = GetPlayersProperties();

            Game.PieceSetup = GamePiece.GetGamePieceSetup();

            int startingPlayerIndex = new Random().Next(0, Game.Players.Count);

            Game.NextTurnPlayer = Game.Players[startingPlayerIndex];

            Game.Moves = new List<GameMove>();
        }

        private void GetPlayersProperties(int playerAmmount)
        {
            var availableColors = new List<GameColor>() { 0, (GameColor)1, (GameColor)2, (GameColor)3 };

            for (int i = 0; i < playerAmmount; i++)
            {
                // Player chooses name

                var playerName = $"Player {i + 1}";
                Console.WriteLine($"Player {i + 1} choose a name: ");
                var playerNameInput = Console.ReadLine();

                if (playerNameInput == "")
                {
                    playerNameInput = playerName;
                }

                // Player chooses color
                Console.WriteLine($"Player {i + 1} choose a color:");

                for (int y = 0; y < availableColors.Count; y++)
                {
                    Console.WriteLine($"{y + 1}) {availableColors[y]}");
                }
                var playerColorInput = 0;
                try
                {
                    var input = Console.ReadLine();
                    if (input == "")
                    {
                        break;
                    }
                    playerColorInput = (int)((GameColor)Convert.ToInt32(input) - 1);
                    availableColors.Remove(availableColors[playerColorInput]);
                }
                catch
                {
                    Console.WriteLine("Input not accepted, choose an available color");
                }

                // Create player
                Game.Players.Add(new GamePlayer()
                {
                    GamePlayerName = playerNameInput,
                    GamePlayerColour = (GameColor)(playerColorInput)
                });
            }
        }

        private int GetPlayerAmount()
        {
            int playerAmmount = 0;
            while (playerAmmount < 2 || playerAmmount > 4)
            {
                Console.WriteLine("Choose how many players: ");
                try { playerAmmount = Convert.ToInt32(Console.ReadLine().Trim()); }
                catch { Console.WriteLine("Input not accepted. Choose between 2 and 4"); }
                Console.WriteLine($"{playerAmmount} players will play!");
            }
            return playerAmmount;
        }

        public void LoadGame()
        {
            //get game from db
        }

        public void PlayGame()
        {
            while (Game.Winner == null)
            {
                Board.PrintBoard();
                Console.WriteLine($"Now it's {Game.NextTurnPlayer.GamePlayerName} turn\n" +
                    $"1) Throw dice\n" +
                    $"2) Save game");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        Dice.ThrowDice();
                        var gamePieceToMove = GetGamePieceToMove();
                        CreateNewMove(gamePieceToMove);
                        if (Game.Moves.Last().Piece != null)
                            ExecuteLastMove();
                        break;

                    case "2":
                        //Sparar spel
                        break;
                }
                if (Dice.LastResult != 6)
                {
                    var currentPlayerIndex = Game.Players.IndexOf(Game.NextTurnPlayer);
                    var nextTurnPlayerIndex = currentPlayerIndex + 1 % (Game.Players.Count() - 1);
                    Game.NextTurnPlayer = Game.Players[nextTurnPlayerIndex];
                }
            }
        }

        public void ExecuteLastMove()
        {
            var originalPosition = Game.Moves.Last().OriginalPosition;
            var currentGamePiece = Game.Moves.Last().Piece;
            var currentGameColor = Game.Moves.Last().Piece.Color;
            var currentPlayer = Game.Moves.Last().Player;
            var diceValue = Game.Moves.Last().DiceThrowResult;
            int newPosition = CalculateNewPositon(originalPosition, diceValue);

            //removes game piece from original cell

            if (originalPosition != null && originalPosition < 40)
            {
                //remove from track
                var originalBoardTrackCellIndex = (int)originalPosition + 10 * (int)currentGameColor % 40;
                Board.Track[originalBoardTrackCellIndex] = null;
            }
            else if (originalPosition >= 40 && originalPosition < 44)
            {
                //remove from final track
                var originalFinalTrackCellIndex = (int)originalPosition - 40;
                Board.FinalTracks[(int)currentGameColor][originalFinalTrackCellIndex] = null;
            }

            //add game piece to target cell

            if (newPosition < 40)
            {
                //add to track
                var targetBoardTrackCellIndex = (int)newPosition + 10 * (int)currentGameColor % 40;
                var tmpCell = Board.Track[targetBoardTrackCellIndex];
                if (tmpCell != null)
                {
                    //update position av opponents piece
                    if (tmpCell.Color != currentGameColor)
                        tmpCell.TrackPosition = null;
                }
                Board.Track[targetBoardTrackCellIndex] = currentGamePiece;
            }
            else if (newPosition >= 40 && newPosition < 44)
            {
                //add to final track
                var targetFinalTrackCellIndex = (int)newPosition - 40;
                Board.FinalTracks[(int)currentGameColor][targetFinalTrackCellIndex] = currentGamePiece;
            }
            //update piece position
            currentGamePiece.TrackPosition = newPosition;

            if (newPosition == 44)
            {
                var piecesAtFinish = Game.PieceSetup.Where(p => p.Color == currentGameColor && p.TrackPosition == 44).Count();
                if (piecesAtFinish == 4)
                {
                    Game.Winner = currentPlayer;
                }
            }
        }

        private int CalculateNewPositon(int? originalPosition, int diceValue)
        {
            var newPosition = (originalPosition == null) ? diceValue : (int)originalPosition + diceValue;
            newPosition = (newPosition > 44) ? 88 - newPosition : newPosition;
            return newPosition;
        }

        private GamePiece GetGamePieceToMove()
        {
            GamePiece gamePieceToMove = null;
            List<GamePiece> movablePieces = GetMovableGamePieces();
            if (movablePieces.Count != 0)
            {
                Console.WriteLine("Choose your game piece:");
                foreach (var gamePiece in movablePieces)
                {
                    Console.WriteLine($"Piece number: {gamePiece.Number} at position {gamePiece.TrackPosition}");
                }
                var chosenPieceIndex = int.Parse(Console.ReadLine());
                gamePieceToMove = movablePieces[chosenPieceIndex];
            }
            else
            {
                Console.WriteLine($"You don't have available moves based on dice result");
            }
            return gamePieceToMove;
        }

        private void CreateNewMove(GamePiece pieceToMove)
        {
            var currentMove = new GameMove()
            {
                Player = Game.NextTurnPlayer,
                Piece = null,
                OriginalPosition = null,
                DiceThrowResult = Dice.LastResult
            };

            if (pieceToMove != null)
            {
                currentMove.Piece = pieceToMove;
                currentMove.OriginalPosition = pieceToMove.TrackPosition;
            }
            Game.Moves.Add(currentMove);
        }

        public List<GamePiece> GetMovableGamePieces()
        {
            //List of Pieces of same color
            var playerPieces = Game.PieceSetup.Where(p => p.Color == Game.NextTurnPlayer.GamePlayerColour).ToList();
            var movablePieces = new List<GamePiece>();
            if (Dice.LastResult != 1 && Dice.LastResult != 6)
            {
                //List of Pieces of same color that are not att null (base)
                playerPieces = playerPieces.Where(p => p.TrackPosition != null).ToList();
            }

            if (playerPieces.Count > 0)
            {
                for (int i = 0; i < playerPieces.Count(); i++)
                {
                    //iteration throe available pieces to se if specifik piece can be moved to target position
                    //piece can not be places att position witch already contains piece of same color
                    //piece can not jump over another piece of same color
                    var originalPosition = playerPieces[i].TrackPosition;
                    var positionAhead = (originalPosition == null) ? -1 : originalPosition;
                    var potencialTrackPosition = CalculateNewPositon(originalPosition, Dice.LastResult);
                    while (positionAhead <= potencialTrackPosition)
                    {
                        positionAhead++;
                        if (playerPieces.FindAll(p => p.TrackPosition == positionAhead).Count > 0)
                            break;

                        if (playerPieces.FindAll(p => p.TrackPosition == potencialTrackPosition).Count == 0 && positionAhead == potencialTrackPosition)
                            movablePieces.Add(playerPieces[i]);
                    }
                }
            }

            return movablePieces;
        }
    }
}