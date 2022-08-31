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
        private readonly WarriorAttackTurn _warriorAttack;

        public OffensiveTriggerFactory(WarriorAttackTurn warriorAttack)
        {
            _warriorAttack = warriorAttack;
        }

        public IOffensiveTrigger CreateTrigger(WeaponsTrigger weaponTriger)
        {
            switch(weaponTriger)
            {
                case WeaponsTrigger.DoubleAttack:
                    return new DoubleAttackTrigger(_warriorAttack);
                case WeaponsTrigger.BonusDamage:
                    return new BonusDamageTrigger(_warriorAttack);
                default:
                    return null;
            }
        }
    }
}
