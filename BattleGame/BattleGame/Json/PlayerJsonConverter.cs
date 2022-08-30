using BattleGame.Game;
using BattleGame.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Json
{
    public class PlayerJsonConverter : JsonConverter<IPlayer>
    {
        public override IPlayer ReadJson(JsonReader reader, Type objectType, IPlayer existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                serializer.Converters.Add(new WeaponJsonConverter());

                JObject item = JObject.Load(reader);
                var name = item["Name"].Value<string>();               
                var health = item["Health"].Value<int>();
                var maxAttack = item["MaxAttack"].Value<int>();
                var maxBlock = item["MaxBlock"].Value<int>();
                var playerType = item["PlayerType"].Value<string>();
                var minAttack = item["MinAttack"].Value<int>();
                var minBlock = item["MinBlock"].Value<int>();

                IWeapon weapon = null;
                if (item["Weapon"] != null)
                {
                    weapon = item["Weapon"].ToObject<IWeapon>(serializer);
                }

                switch (playerType)
                {
                    case "Warrior":
                        return new Warrior()
                        {
                            Name = name,
                            Weapon = weapon,
                            Health = health,
                            MaxAttack = maxAttack,
                            MaxBlock = maxBlock,
                            MinAttack = minAttack,
                            MinBlock = minBlock,
                        };
                    case "Wizard":
                        return new Wizard()
                        {
                            Name = name,
                            Health = health,
                            MaxAttack = maxAttack,
                            MaxBlock = maxBlock,
                            MinAttack = minAttack,
                            MinBlock = minBlock,
                        };
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, IPlayer value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(IPlayer));
        }
    }
}
