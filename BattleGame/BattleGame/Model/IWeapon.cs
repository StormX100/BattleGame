using BattleGame.Game.Commands.WeaponTriger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BattleGame.Model
{
    public interface IWeapon
    {
        WeaponsTrigger Trigger { get; }

        int TriggerChance { get; }

        string Name { get; }
    }
}
