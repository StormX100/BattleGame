using BattleGame.Game.Commander;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.Calculators
{
    public class DealDamageCalculator
    {
        private readonly IWizard _wizard;
        private readonly Random _random;

        public DealDamageCalculator(IWizard wizard, Random random)
        {
            _wizard = wizard;
            _random = random;
        }

        public PlayerAttackTurn Calculate()
        {
            return new PlayerAttackTurn() { Player = _wizard, Value = _random.Next(0, _wizard.MaxAttack), Action = Options.AllAttackTypes.DealDamage };
        }
    }
}
