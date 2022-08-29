using BattleGame.Game.Commands.Calculators;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    class IncreaseMaxBlockCommand : ICastCommand
    {
        private readonly IWizard _wizard;
        private readonly InceraseMaxBlockCalculator _calculator;

        public IncreaseMaxBlockCommand(IWizard wizard, InceraseMaxBlockCalculator calculator)
        {
            _wizard = wizard;
            _calculator = calculator;
        }

        public CommandResult Execute()
        {
            _wizard.MaxBlock += _calculator.Calculate();
            return new CommandResult();
        }
    }
}
