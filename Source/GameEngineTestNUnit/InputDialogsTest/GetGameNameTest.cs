using GameEngine;
using GameEngine.Assets;
using GameEngine.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameEngineTestNUnit.InputDialogsTest
{
    internal class GetGameNameTest
    {
        [Test]
        public void Given_Name_From_Input_Expect_Name_As_Output()
        {
            // Arrange
            var input = new StringReader("abc");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var expectedOutput =
                $"Name The Game: \r\n";

            // Act
            var result = InputDialogs.GetGameName();

            // Assert
            Assert.AreEqual(expectedOutput, output.ToString());
            Assert.AreEqual(result, "abc");

        }
    }
}
