using BattleGame.Game.Commander;
using BattleGame.Game.Options;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.Calculators
{
    public class InceraseMaxBlockCalculator : ICalculator
    {
        private readonly IWizard _wizard;
        private Random _random;

        public InceraseMaxBlockCalculator(IWizard wizard, Random random)
        {
            _wizard = wizard;
            _random = random;
        }

        public PlayerAttackTurn Calculate()
        {
            return new PlayerAttackTurn() { Player = _wizard, Action = AllAttackTypes.IncreaseMaxBlock, Value = _random.Next(1, _wizard.MaxBlock / 2) };
        }
    }
}
