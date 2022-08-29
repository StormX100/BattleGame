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
        private WarriorAttack _warriorAttack;

        public WeaponTriggers Trigger => WeaponTriggers.DoubleAttack;

        public DoubleAttackTrigger(WarriorAttack attack)
        {
            _warriorAttack = attack;
        }

        public void Execute()
        {
            _warriorAttack.IncreasedValue = _warriorAttack.Attack;
            _warriorAttack.Attack *= 2;            
            _warriorAttack.Trigger = WeaponTriggers.DoubleAttack;
        }
    }
}
