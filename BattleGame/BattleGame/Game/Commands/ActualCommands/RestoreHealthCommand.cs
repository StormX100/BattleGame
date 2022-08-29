using BattleGame.Game.Commands.Calculators;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    class RestoreHealthCommand : ICastCommand
    {
        private readonly IWizard _wizard;
        private readonly RestoreHealthCalculator _calculator;

        public RestoreHealthCommand(IWizard wizard, RestoreHealthCalculator calculator)
        {
            _wizard = wizard;
            _calculator = calculator;
        }

        public CommandResult Execute()
        {
            _wizard.Health += _calculator.Calculate();

            return new CommandResult();
        }      
    }
}
