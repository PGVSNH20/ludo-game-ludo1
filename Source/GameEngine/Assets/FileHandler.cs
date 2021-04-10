using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace GameEngine.Assets
{
    public class FileHandler
    {
        public static LudoGame ReadFromFile(string name)
        {
            var jsonString = File.ReadAllText($"SavedGames/{name}.json");
            var game = JsonSerializer.Deserialize<LudoGame>(jsonString);
            return game;
        }

        public static void WriteToFile(string name, LudoGame game)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(game, options);
            File.WriteAllText($"SavedGames/{name}.json", jsonString);
        }
    }
}