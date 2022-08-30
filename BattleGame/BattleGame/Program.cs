


using BattleGame.Model;
using BattleGame.Game;

using System;
using BattleGame.Model.Weapons;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BattleGame.Json;

namespace BattleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer firstPlayer = null;
            IPlayer secondPlayer = null;
            
            using (StreamReader streamReader = new StreamReader("../../../Files/Player1.json"))
            {
                string json = streamReader.ReadToEnd();

                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new WeaponJsonConverter());
                settings.Converters.Add(new PlayerJsonConverter());

                firstPlayer = JsonConvert.DeserializeObject<IPlayer>(json, settings);
            }

            using (StreamReader streamReader = new StreamReader("../../../Files/Player2.json"))
            {
                string json = streamReader.ReadToEnd();

                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new WeaponJsonConverter());
                settings.Converters.Add(new PlayerJsonConverter());

                secondPlayer = JsonConvert.DeserializeObject<IPlayer>(json, settings);
            }

            BattleRoundGame game = new BattleRoundGame(firstPlayer, secondPlayer);
            game.StartGame();
        }
    }
}
