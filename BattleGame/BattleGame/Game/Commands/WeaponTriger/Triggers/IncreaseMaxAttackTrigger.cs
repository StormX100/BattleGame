using BattleGame.Game.Commander;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger
{
    public class IncreaseMaxAttackTrigger : ISelfOffensiveTrigger
    {
        private readonly IWarrior _warrior;
        private readonly WarriorAttack _warriorAttack;

        public WeaponTriggers Trigger { get => WeaponTriggers.IncreaseMaxAttack; }

        public IncreaseMaxAttackTrigger(IWarrior warrior, WarriorAttack warriorAttack)
        {
            _warrior = warrior;
            _warriorAttack = warriorAttack;
        }

        public void Execute()
        {
            _warrior.MaxAttack += 10;
            _warriorAttack.IncreasedValue += 10;
            _warriorAttack.Trigger = WeaponTriggers.IncreaseMaxAttack;
        }
    }
}
