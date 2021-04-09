using System;
using Xunit;
using GameEngine;
using GameEngine.Models;
using GameEngine.Assets;

namespace GameEngineTest
{
    public class GameDiceTest
    {
        [Fact]
        public void When_ThrowDice_Expect_ValueBetween1And6()
        {
            // Arrange
            GameDice gameDice = new GameDice();

            // Act
            int[] results = new int[100];

            for (int i = 0; i < 100; i++)
            {
                gameDice.ThrowDice();
                results[i] = gameDice.Result;
            }

            // Assert
            Assert.All(results, item => Assert.InRange(item, 0, 7));
        }
    }
}