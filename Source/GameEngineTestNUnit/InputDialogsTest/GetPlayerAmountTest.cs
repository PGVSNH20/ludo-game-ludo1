using GameEngine;
using GameEngine.Assets;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameEngineTestNUnit.InputDialogsTest
{
    internal class GetPlayerAmountTest
    {
        [Test]
        public void Given_Input2_Expect_Int2()
        {
            var input = new StringReader("2");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var playerAmount = InputDialogs.GetPlayerAmount();
            Assert.AreEqual(2, playerAmount);
            Assert.AreEqual("Choose how many players (2, 3 or 4): \r\n2 players will play!\r\n", output.ToString());
        }

        [Test]
        public void Given_Input3_Expect_Int3()
        {
            var input = new StringReader("3");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var playerAmount = InputDialogs.GetPlayerAmount();
            Assert.AreEqual(3, playerAmount);
            Assert.AreEqual("Choose how many players (2, 3 or 4): \r\n3 players will play!\r\n", output.ToString());
        }

        [Test]
        public void Given_Input4_Expect_Int4()
        {
            var input = new StringReader("4");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var playerAmount = InputDialogs.GetPlayerAmount();
            Assert.AreEqual(4, playerAmount);
            Assert.AreEqual("Choose how many players (2, 3 or 4): \r\n4 players will play!\r\n", output.ToString());
        }

        [Test]
        public void Given_WrongINputs_Expect_()
        {
            var input = new StringReader(
                $"5\r\n" +
                $"1\r\n" +
                $"abc\r\n" +
                $"3");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var expectedOutput =
                $"Choose how many players (2, 3 or 4): \r\n" +
                $"Choose between 2 and 4\r\n" +
                $"Choose how many players (2, 3 or 4): \r\n" +
                $"Choose between 2 and 4\r\n" +
                $"Choose how many players (2, 3 or 4): \r\n" +
                $"Input not accepted. Choose between 2 and 4\r\n" +
                $"Choose how many players (2, 3 or 4): \r\n" +
                $"3 players will play!\r\n";

            var playerAmount = InputDialogs.GetPlayerAmount();
            Assert.AreEqual(expectedOutput, output.ToString());
            Assert.AreEqual(3, playerAmount);
        }
    }
}