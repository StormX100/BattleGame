using BattleGame.Game.Commander;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger
{
    public class DoubleAttackTrigger : IOffensiveTrigger
    {
        private WarriorAttackTurn _warriorAttack;

        public WeaponsTrigger Trigger => WeaponsTrigger.DoubleAttack;

        public DoubleAttackTrigger(WarriorAttackTurn warriorAttack)
        {
            _warriorAttack = warriorAttack;
        }

        public void Execute()
        {
            _warriorAttack.Value *= 2;
            _warriorAttack.IncreasedValue = _warriorAttack.Value;           
            _warriorAttack.Trigger = WeaponsTrigger.DoubleAttack;
        }
    }
}
