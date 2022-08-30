
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
    public class IncreaseMaxAttackCommand : ICastCommand
    {
        private readonly PlayerAttackTurn _playerAttackTurn;
        private readonly IWizard _wizard;
        private readonly IPlayer _enemy;

        public IncreaseMaxAttackCommand(PlayerAttackTurn playerAttackTurn, IWizard wizard, IPlayer enemy)
        {
            _playerAttackTurn = playerAttackTurn;
            _wizard = wizard;
            _enemy = enemy;
        }

        public CommandResult Execute()
        {
            _wizard.MaxAttack += _playerAttackTurn.Value;
            return new CommandResult() { PlayerAttackTurn = _playerAttackTurn, PlayerDefenseTurn = new PlayerDefenseTurn() { Player = _enemy } };
        }
    }
}
