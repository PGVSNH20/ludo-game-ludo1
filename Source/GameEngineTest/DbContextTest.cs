using GameEngine;
using GameEngine.DatabaseContext;
using GameEngine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngineTest
{
    public class DbContextTest
    {
        [Fact]
        public void Given_NewGameSetUpSavedToDb_Expect_CorespondingDataInDb()
        {
            // Arrange
            var players = new List<GamePlayer>()
                    {
                        new GamePlayer(){ Name = "Bob", Color = 0},
                        new GamePlayer(){ Name = "Rob", Color = (GameColor)1, Type = (PlayerType)1}
                    };
            var newLudoGame = new LudoGame()
            {
                GamePlayers = new GamePlayers()
                {
                    Players = players
                },
                PieceSetup = new List<GamePiece>()
                {
                    new GamePiece() { Color = (GameColor)0, Number = 1, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)0, Number = 2, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)0, Number = 3, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)0, Number = 4, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)1, Number = 1, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)1, Number = 2, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)1, Number = 3, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)1, Number = 4, TrackPosition = null }
                },
                NextPlayer = players[0],
                Status = "Created"
            };
            var firstGameRunner = new GameRunner()
            {
                Game = newLudoGame
            };

            var optionsBuilder = new DbContextOptionsBuilder<LudoGameDbContext>();
            optionsBuilder.UseInMemoryDatabase("testDb1");
            var db = new LudoGameDbContext(optionsBuilder.Options);

            // Act

            firstGameRunner.SaveGameToDataBase(db);
            var secondGameRunner = new GameRunner();
            var games = secondGameRunner.LoadAllGamesFromDataBase(db);
            secondGameRunner.LoadGameFromDatabase(games[0], db);

            // Assert
            Assert.Single(games);
            Assert.Equal("Created", games[0].Status);
            Assert.Equal(2, secondGameRunner.Game.GamePlayers.PlayerCount);
            Assert.Equal(8, secondGameRunner.Game.PieceSetup.Count);
        }

        [Fact]
        public void Given_MoveExecutet_Expect_CorespondingDataInDb()
        {
            // Arrange
            var players = new List<GamePlayer>()
                    {
                        new GamePlayer(){ Name = "Bob", Color = 0},
                        new GamePlayer(){ Name = "Rob", Color = (GameColor)1, Type = (PlayerType)1}
                    };
            var newLudoGame = new LudoGame()
            {
                GamePlayers = new GamePlayers()
                {
                    Players = players
                },
                PieceSetup = new List<GamePiece>()
                {
                    new GamePiece() { Color = (GameColor)0, Number = 1, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)0, Number = 2, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)0, Number = 3, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)0, Number = 4, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)1, Number = 1, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)1, Number = 2, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)1, Number = 3, TrackPosition = null },
                    new GamePiece() { Color = (GameColor)1, Number = 4, TrackPosition = null }
                },
                NextPlayer = players[0],
                Status = "Created"
            };
            var firstGameRunner = new GameRunner()
            {
                Game = newLudoGame
            };

            var optionsBuilder = new DbContextOptionsBuilder<LudoGameDbContext>();
            optionsBuilder.UseInMemoryDatabase("testDb2");
            var db = new LudoGameDbContext(optionsBuilder.Options);

            firstGameRunner.SaveGameToDataBase(db);

            var newMove = new GameMove()
            {
                Piece = firstGameRunner.Game.PieceSetup[0],
                Player = firstGameRunner.Game.GamePlayers.Players[0],
                DiceThrowResult = 6,
            };
            firstGameRunner.Game.Moves.Add(newMove);
            firstGameRunner.Game.PieceSetup[0].TrackPosition = 5;
            firstGameRunner.Game.NextPlayer = firstGameRunner.Game.GamePlayers.Players[1];
            firstGameRunner.Game.Status = "In progress (moves 1)";

            // Act

            firstGameRunner.SaveMoveToDataBase(db);

            var secondGameRunner = new GameRunner();
            var games = secondGameRunner.LoadAllGamesFromDataBase(db);
            secondGameRunner.LoadGameFromDatabase(games[0], db);

            // Assert
            Assert.Single(secondGameRunner.Game.Moves);
            Assert.Equal("In progress (moves 1)", games[0].Status);
            Assert.Equal(2, secondGameRunner.Game.GamePlayers.PlayerCount);
            Assert.Equal(8, secondGameRunner.Game.PieceSetup.Count);
            Assert.Equal(5, secondGameRunner.Game.PieceSetup[0].TrackPosition);
            Assert.Equal(6, secondGameRunner.Game.Moves.Last().DiceThrowResult);
        }
    }
}