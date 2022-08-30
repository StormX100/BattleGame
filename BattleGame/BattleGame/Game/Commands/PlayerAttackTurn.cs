using BattleGame.Game.Options;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commander
{
    public class PlayerAttackTurn
    {
        public IPlayer Player { get; set; }

        public int Value { get; set; }

        public AllAttackTypes Action { get; set;}
    }
}
