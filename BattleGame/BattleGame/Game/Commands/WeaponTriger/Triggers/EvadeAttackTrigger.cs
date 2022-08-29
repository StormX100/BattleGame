using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger
{
    class EvadeAttackTrigger : ISelfDefensiveTrigger
    {
        private readonly IWarrior _warrior;

        public WeaponTriggers Trigger => WeaponTriggers.EvadeAttack;

        public EvadeAttackTrigger(IWarrior warrior)
        {
            _warrior = warrior;
        }

        public void Execute()
        {
            _warrior.MaxBlock = int.MaxValue;
        }
    }
}
