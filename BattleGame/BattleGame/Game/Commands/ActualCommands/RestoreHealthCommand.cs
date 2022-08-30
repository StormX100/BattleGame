using BattleGame.Game.Commander;
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
        private readonly PlayerAttackTurn _playerAttackTurn;
        private readonly IWizard _wizard;

        public RestoreHealthCommand(PlayerAttackTurn playerAttackTurn, IWizard wizard)
        {
            _playerAttackTurn = playerAttackTurn;
            _wizard = wizard;

        }

        public CommandResult Execute()
        {
            _wizard.Health += _playerAttackTurn.Value;

            return new CommandResult() { PlayerAttackTurn = _playerAttackTurn };
        }      
    }
}
