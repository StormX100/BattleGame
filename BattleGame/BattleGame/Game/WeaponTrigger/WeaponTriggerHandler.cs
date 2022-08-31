using BattleGame.Game.Commander;
using BattleGame.Game.Commands.WeaponTriger;
using BattleGame.Game.WeaponTrigger;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    public class WeaponTriggerHandler : IWeaponTriggerHandler
    {
        public bool IsTriggered(IWeaponTrigger weaponTrigger, int triggerChance)
        {
            if (weaponTrigger == null || weaponTrigger.Trigger.Equals(WeaponsTrigger.None))
            {
                return false;
            }

            Random random = new Random();
            if (random.Next(1, 100) < triggerChance)
            {
                return true;
            }

            return false;
        }       
    }
}
