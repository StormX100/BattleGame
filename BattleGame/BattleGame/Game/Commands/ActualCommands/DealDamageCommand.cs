using BattleGame.Game.Commands.Calculators;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    public class DealDamageCommand : ICastCommand
    {
        private readonly IWizard _wizard;
        private readonly IPlayer _enemy;
        private readonly DealDamageCalculator _calculator;

        public DealDamageCommand(IWizard wizard, IPlayer enemy, DealDamageCalculator calculator)
        {
            _wizard = wizard;
            _enemy = enemy;
            _calculator = calculator;
        }

        public CommandResult Execute()
        {
            var damage = _calculator.Calculate();

            if (damage > _enemy.MaxBlock)
            {
                _enemy.Health = damage - _enemy.MaxBlock;
            }

            return new CommandResult();
        }
    }
}
