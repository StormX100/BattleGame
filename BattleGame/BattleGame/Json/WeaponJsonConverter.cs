using BattleGame.Game;
using BattleGame.Model;
using BattleGame.Model.Weapons;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Json
{
    public class WeaponJsonConverter : JsonConverter<IWeapon>
    {
        public override IWeapon ReadJson(JsonReader reader, Type objectType, IWeapon existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject item = JObject.Load(reader);
                var name = item["Name"].Value<string>();

                switch(name)
                {
                    case "Daedalus":
                        return new Daedalus() { };
                    case "Butterfly":
                        return new Butterfly();
                    case "DivineRapier":
                        return new DivineRapier();
                    case "MonkeyKingBar":
                        return new MonkeyKingBar();
                    case "ShivasGuard":
                        return new Daedalus();
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, IWeapon value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(IWeapon));
        }
    }
}
