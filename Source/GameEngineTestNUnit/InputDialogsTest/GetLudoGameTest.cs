using GameEngine.Models;
using GameEngine.Assets;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GameEngineTestNUnit.InputDialogsTest
{
    internal class GetLudoGameTest
    {

        [Test]
        public void Given_1_Game_In_Database_Expect_1_Game_From_Database()
        {
            //Arange
            var LudoGames = new List<LudoGame>()
            {
                new LudoGame(){LudoGameId = 1, GameName = "testGame", Created = DateTime.Now, Status = "Created"}
            };

            //Act
            var input = new StringReader("1");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var expectedOutput =
                $"Choose game from list:\r\n" +
                $"1) {LudoGames[0].GameName} (id: {LudoGames[0].LudoGameId}), created: {LudoGames[0].Created.ToString("yyyy:MM:dd")}, status: {LudoGames[0].Status}\r\n";
            var returnGame = InputDialogs.GetLudoGame(LudoGames);
            //Assert
            Assert.AreEqual(expectedOutput, output.ToString());
            //Assert.AreEqual(GamePieces[12], gamePiece);
        }

    }
}
