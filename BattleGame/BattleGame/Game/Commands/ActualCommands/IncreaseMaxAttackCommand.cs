
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
    class IncreaseMaxAttackCommand : ICastCommand
    {
        private readonly PlayerAttackTurn _playeAttackTurn;
        private readonly IWizard _wizard;

        public IncreaseMaxAttackCommand(PlayerAttackTurn playeAttackTurn, IWizard wizard)
        {
            _playeAttackTurn = playeAttackTurn;
            _wizard = wizard;
        }

        public CommandResult Execute()
        {
            _wizard.MaxAttack += _playeAttackTurn.Value;
            return new CommandResult() { PlayerAttackTurn = _playeAttackTurn };
        }
    }
}
