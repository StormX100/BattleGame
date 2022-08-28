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

        public RestoreHealthCalculator(IWizard wizard)
        {
            _wizard = wizard;
        }

        public int Calculate()
        {
            Random rand = new Random();
            return rand.Next(1, _wizard.Health / 2);
        }
    }
}
