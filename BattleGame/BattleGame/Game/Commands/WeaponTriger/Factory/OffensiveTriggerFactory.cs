using BattleGame.Game.Commander;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger
{
    public class OffensiveTriggerFactory
    {
        private readonly WarriorAttack _warriorAttack;

        public OffensiveTriggerFactory(WarriorAttack warriorAttack)
        {
            _warriorAttack = warriorAttack;
        }

        public IOffensiveTrigger CreateTrigger(WeaponTriggers weaponTriger)
        {
            switch(weaponTriger)
            {
                case WeaponTriggers.DoubleAttack:
                    return new DoubleAttackTrigger(_warriorAttack);
                case WeaponTriggers.BonusDamage:
                    return new BonusDamageTrigger(_warriorAttack);
                default:
                    return null;
            }
        }
    }
}
