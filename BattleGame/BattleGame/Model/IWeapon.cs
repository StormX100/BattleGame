using BattleGame.Game.Commands.WeaponTriger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model
{
    public interface IWeapon
    {
        WeaponTriggers Trigger { get; }

        int TriggerChance { get; }
    }
}
