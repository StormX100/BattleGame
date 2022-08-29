using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger.Factory
{
    public class SelfDefensiveTriggerFactory
    {
        private readonly IWarrior _warrior;

        public SelfDefensiveTriggerFactory(IWarrior warrior)
        {
            _warrior = warrior;
        }

        public ISelfDefensiveTrigger CreateTrigger(WeaponTriggers weaponTriger)
        {
            switch (weaponTriger)
            {
                case WeaponTriggers.DoubleAttack:
                    return new IncreaseMaxBlockTrigger(_warrior);
                case WeaponTriggers.EvadeAttack:
                    return new EvadeAttackTrigger(_warrior);
                default:
                    return null;
            }
        }
    }
}
