using GameEngine;
using GameEngine.Assets;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngineTest.ToolsTest
{
    public class CalculateNewPositionTest
    {
        [Fact]
        public void Given_StartPositionNull_DiceValue6_Expect_NewPosition5()
        {
            //Arrange
            int? originalPosition = null;
            int diceValue = 6;
            //Act

            var newPosition = Tools.CalculateNewPositon(originalPosition, diceValue);

            //Assert

            Assert.Equal(5, newPosition);
        }

        [Fact]
        public void Given_StartPosition30_DiceValue6_Expect_NewPosition36()
        {
            //Arrange
            int? originalPosition = 30;
            int diceValue = 6;
            //Act

            var newPosition = Tools.CalculateNewPositon(originalPosition, diceValue);

            //Assert

            Assert.Equal(36, newPosition);
        }

        [Fact]
        public void Given_StartPosition43_DiceValue2_Expect_NewPosition43()
        {
            //Arrange
            int? originalPosition = 43;
            int diceValue = 2;
            //Act

            var newPosition = Tools.CalculateNewPositon(originalPosition, diceValue);

            //Assert

            Assert.Equal(43, newPosition);
        }
    }
}