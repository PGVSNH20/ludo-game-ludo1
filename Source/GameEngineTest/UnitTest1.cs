using System;
using Xunit;
using GameEngine;
using GameEngine.Models;

namespace GameEngineTest
{
    public class UnitTest1
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
                results[i] = gameDice.LastResult;
            }

            // Assert
            Assert.Collection(results, item => Assert.InRange(item, 0, 7));
        }
    }
}