using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngineTest
{
    public class GamePieceTest
    {
        [Fact]
        public void Given_4GamePlayers_Expect_16GamePieces()
        {
            //Arrange
            var gamePlayers = new List<GamePlayer>()
            {
                new GamePlayer() { GamePlayerColour = 0 },
                new GamePlayer() { GamePlayerColour = (GameColor)1 },
                new GamePlayer() { GamePlayerColour = (GameColor)2 },
                new GamePlayer() { GamePlayerColour = (GameColor)3 }
            };

            //Act

            var gamePieceSetUp = GamePiece.GetGamePieceSetup(gamePlayers);

            //Assert

            Assert.Equal(16, gamePieceSetUp.Count());
        }

        [Fact]
        public void Given_2GamePlayers_Expect_4RedGamePiecesAnd4GreenPieces()
        {
            //Arrange
            var gamePlayers = new List<GamePlayer>()
            {
                new GamePlayer() { GamePlayerColour = (GameColor)1 },
                new GamePlayer() { GamePlayerColour = (GameColor)3 }
            };

            //Act

            var gamePieceSetUp = GamePiece.GetGamePieceSetup(gamePlayers);

            //Assert

            Assert.Equal(8, gamePieceSetUp.Count());
            Assert.Equal((GameColor)1, gamePieceSetUp[0].Color);
            Assert.Equal((GameColor)1, gamePieceSetUp[1].Color);
            Assert.Equal((GameColor)1, gamePieceSetUp[2].Color);
            Assert.Equal((GameColor)1, gamePieceSetUp[3].Color);
            Assert.Equal((GameColor)3, gamePieceSetUp[4].Color);
            Assert.Equal((GameColor)3, gamePieceSetUp[5].Color);
            Assert.Equal((GameColor)3, gamePieceSetUp[6].Color);
            Assert.Equal((GameColor)3, gamePieceSetUp[7].Color);
        }
    }
}