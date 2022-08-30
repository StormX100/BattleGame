using BattleGame.Game.Options;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    public class PlayerDefenseTurn
    {
        public IPlayer Player { get; set; }

        public int Defense { get; set; }

        public int DamageTaken { get; set; }
    }
}
