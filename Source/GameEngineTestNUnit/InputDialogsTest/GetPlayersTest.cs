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
    internal class GetPlayersTest
    {
        [Test]
        public void Given_Information_Expect_3Players()
        {
            var palyerAmount = 3;
            var input = new StringReader(
                $"Bob\r\n" +
                $"2\r\n" +
                $"1\r\n" +
                $"Rob\r\n" +
                $"0\r\n" +
                $"3\r\n" +
                $"Bil\r\n" +
                $"99\r\n" +
                $"abc\r\n" +
                $"5\r\n" +
                $"\r\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var expectedOutput =
                $"Player 1 choose a name: \r\n" +
                $"Choose type for Bob: \r\n" +
                $"1) Human\r\n" +
                $"2) Robot\r\n" +
                $"Bob choose a color:\r\n" +
                $"1) Blue\r\n" +
                $"2) Red\r\n" +
                $"3) Yellow\r\n" +
                $"4) Green\r\n" +
                $"Player 2 choose a name: \r\n" +
                $"Choose type for Rob: \r\n" +
                $"1) Human\r\n" +
                $"2) Robot\r\n" +
                $"Rob choose a color:\r\n" +
                $"1) Red\r\n" +
                $"2) Yellow\r\n" +
                $"3) Green\r\n" +
                $"Player 3 choose a name: \r\n" +
                $"Choose type for Bil: \r\n" +
                $"1) Human\r\n" +
                $"2) Robot\r\n" +
                $"Bil choose a color:\r\n" +
                $"1) Red\r\n" +
                $"2) Yellow\r\n" +
                $"Input not accepted, choose an available color\r\n" +
                $"Input not accepted, choose an available color\r\n";

            var players = InputDialogs.GetPlayers(palyerAmount);
            Assert.AreEqual(3, players.Count);
            Assert.AreEqual(expectedOutput, output.ToString());
            Assert.AreEqual("Bob", players[0].Name);
            Assert.AreEqual("Bil", players[1].Name);
            Assert.AreEqual("Rob", players[2].Name);
            Assert.AreEqual((GameColor)0, players[0].Color);
            Assert.AreEqual((GameColor)1, players[1].Color);
            Assert.AreEqual((GameColor)3, players[2].Color);
        }
    }
}