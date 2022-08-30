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
        private readonly WarriorAttackTurn _warriorAttack;

        public WeaponsTrigger Trigger { get => WeaponsTrigger.IncreaseMaxAttack; }

        public IncreaseMaxAttackTrigger(IWarrior warrior, WarriorAttackTurn warriorAttack)
        {
            _warrior = warrior;
            _warriorAttack = warriorAttack;
        }

        public void Execute()
        {
            int increasedMaxAttack = 20;

            _warrior.MaxAttack += increasedMaxAttack;
            _warrior.MinAttack += increasedMaxAttack;
            _warriorAttack.IncreasedValue += increasedMaxAttack;
            _warriorAttack.Trigger = WeaponsTrigger.IncreaseMaxAttack;
        }
    }
}
