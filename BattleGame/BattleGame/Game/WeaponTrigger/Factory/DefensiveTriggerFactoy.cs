using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger.Factory
{
    public class DefensiveTriggerFactoy
    {
        private readonly WarriorDefenceTurn _warriorDefense;

        public DefensiveTriggerFactoy(WarriorDefenceTurn warriorDefense)
        {
            _warriorDefense = warriorDefense;
        }

        public IDefensiveTrigger CreateTrigger(WeaponsTrigger weaponTriger)
        {
            switch (weaponTriger)
            {
                case WeaponsTrigger.EvadeAttack:
                    return new EvadeAttackTrigger(_warriorDefense);
                default:
                    return null;
            }
        }
    }
}

