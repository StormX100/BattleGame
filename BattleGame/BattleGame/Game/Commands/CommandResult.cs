using BattleGame.Game.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    public class CommandResult
    {
        public PlayerAttackTurn PlayerAttackTurn { get; set; }

        public PlayerDefenseTurn PlayerDefenseTurn { get; set; }

        public int DamageTaken { get; set; }
    }
}
