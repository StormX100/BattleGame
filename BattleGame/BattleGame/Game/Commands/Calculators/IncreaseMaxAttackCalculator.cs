using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.Calculators
{
    public class IncreaseMaxAttackCalculator : ICalculator
    {
        private readonly IWizard _wizard;

        public IncreaseMaxAttackCalculator(IWizard wizard)
        {
            _wizard = wizard;
        }

        public int Calculate()
        {
            Random rand = new Random();
            return rand.Next(1, _wizard.MaxAttack / 2);
        }
    }
}
