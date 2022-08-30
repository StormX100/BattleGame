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
        public WeaponsTrigger Trigger => WeaponsTrigger.BonusDamage;

        public int TriggerChance => 30;
    }
}
