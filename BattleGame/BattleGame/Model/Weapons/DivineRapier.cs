using BattleGame.Game.Commands.WeaponTriger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model
{
    class DivineRapier : IWeapon
    {
        public WeaponTriggers Trigger => WeaponTriggers.BonusDamage;

        public int TriggerChance => 30;
    }
}
