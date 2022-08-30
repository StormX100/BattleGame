using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model.Weapons
{
    class ShivasGuard : IWeapon
    {
        public WeaponsTrigger Trigger => WeaponsTrigger.IncreaseMaxBlock;

        public int TriggerChance => 50;
    }
}
