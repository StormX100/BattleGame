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
        private readonly WarriorAttackTurn _warriorAttack;

        public SelfOffensiveTriggerFactory(IWarrior warrior, WarriorAttackTurn warriorAttack)
        {
            _warrior = warrior;
            _warriorAttack = warriorAttack;
        }

        public ISelfOffensiveTrigger CreateTrigger(WeaponsTrigger weaponTrigger)
        {
            switch (weaponTrigger)
            {
                case WeaponsTrigger.IncreaseMaxAttack:
                    return new IncreaseMaxAttackTrigger(_warrior, _warriorAttack);
                default:
                    return null;
            }
        }
    }
}
