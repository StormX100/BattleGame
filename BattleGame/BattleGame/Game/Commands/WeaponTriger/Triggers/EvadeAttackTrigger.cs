using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger
{
    class EvadeAttackTrigger : IDefensiveTrigger
    {
        private readonly WarriorDefence _warriorDefense;

        public WeaponsTrigger Trigger => WeaponsTrigger.EvadeAttack;

        public EvadeAttackTrigger(WarriorDefence warriorDefense)
        {
            _warriorDefense = warriorDefense;
        }

        public void Execute()
        {
            _warriorDefense.Defense = int.MaxValue;
            _warriorDefense.IncreasedValue = int.MaxValue;
            _warriorDefense.Trigger = WeaponsTrigger.EvadeAttack;
        }
    }
}
