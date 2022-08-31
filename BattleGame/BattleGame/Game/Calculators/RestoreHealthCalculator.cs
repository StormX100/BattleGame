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
    public class RestoreHealthCalculator : ICalculator
    {
        private readonly IWizard _wizard;
        private Random _random;

        public RestoreHealthCalculator(IWizard wizard, Random random)
        {
            _wizard = wizard;
            _random = random;
        }

        public PlayerAttackTurn Calculate()
        {
            return new PlayerAttackTurn() { Player = _wizard, Action = AllAttackTypes.RestoreHealth, Value = _random.Next(1, _wizard.Health / 2) };
        }
    }
}
