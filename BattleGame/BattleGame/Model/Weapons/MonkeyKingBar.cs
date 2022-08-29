using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model.Weapons
{
    class MonkeyKingBar : IWeapon
    {
        public WeaponTriggers Trigger => WeaponTriggers.IncreaseMaxAttack;

        public int TriggerChance => 50;
    }
}
