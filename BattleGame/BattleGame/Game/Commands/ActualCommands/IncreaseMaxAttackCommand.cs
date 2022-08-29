
using BattleGame.Game.Commands.Calculators;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    class IncreaseMaxAttackCommand : ICastCommand
    {
        private readonly IWizard _wizard;
        private readonly IncreaseMaxAttackCalculator _calculator;

        public IncreaseMaxAttackCommand(IWizard wizard, IncreaseMaxAttackCalculator calculator)
        {
            _wizard = wizard;
            _calculator = calculator;
        }

        public CommandResult Execute()
        {
            _wizard.MaxAttack += _calculator.Calculate();
            return new CommandResult();
        }
    }
}
