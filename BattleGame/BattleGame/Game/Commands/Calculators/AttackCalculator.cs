using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.Calculators
{
    public class AttackCalculator : ICalculator
    {
        private readonly IWarrior _warrior;

        public AttackCalculator(IWarrior warrior)
        {
            _warrior = warrior;
        }

        public int Calculate()
        {
            Random rand = new Random();
            return rand.Next(1, _warrior.MaxAttack);
        }
    }
}
