using BattleGame.Game.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game
{
    public interface ICalculator
    {
        public PlayerAttackTurn Calculate();
    }
}
