using BattleGame.Game.Commander;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger
{
    public class SelfOffensiveTriggerFactory
    {
        private readonly IWarrior _warrior;
        private readonly WarriorAttack _warriorAttack;

        public SelfOffensiveTriggerFactory(IWarrior warrior, WarriorAttack warriorAttack)
        {
            _warrior = warrior;
            _warriorAttack = warriorAttack;
        }

        public ISelfOffensiveTrigger CreateTrigger(WeaponTriggers weaponTrigger)
        {
            switch (weaponTrigger)
            {
                case WeaponTriggers.IncreaseMaxAttack:
                    return new IncreaseMaxAttackTrigger(_warrior, _warriorAttack);
                default:
                    return null;
            }
        }
    }
}
