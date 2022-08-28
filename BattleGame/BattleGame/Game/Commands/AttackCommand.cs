using BattleGame.Game.Commands;
using BattleGame.Game.Commands.Calculators;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game
{
    public class AttackCommand : IAttackCommand
    {
        private readonly IWarrior _warrior;
        private readonly IPlayer _enemy;
        private readonly AttackCalculator _calculator;

        public AttackCommand(IWarrior warrior, IPlayer enemy, AttackCalculator calculator)
        {
            _warrior = warrior;
            _enemy = enemy;
            _calculator = calculator;
        }

        public CommandResult Execute()
        {
            int attack = _calculator.Calculate();

            if(attack > _enemy.MaxBlock)
            {
                _enemy.Health = attack - _enemy.MaxBlock;
            }

            return new CommandResult();
        }
    }
}
