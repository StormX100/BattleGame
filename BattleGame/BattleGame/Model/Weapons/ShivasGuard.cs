using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model.Weapons
{
    class ShivasGuard : IWeapon
    {
        public WeaponTriggers Trigger => WeaponTriggers.IncreaseMaxBlock;

        public int TriggerChance => 50;
    }
}
