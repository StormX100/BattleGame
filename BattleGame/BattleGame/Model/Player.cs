using BattleGame.Game;
using BattleGame.Game.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model
{
    public abstract class Player : IPlayer
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int MaxAttack { get; set; }

        public int MaxBlock { get; set; }

        public int MinAttack { get; set; }

        public int MinBlock { get; set; }

        public abstract PlayerType PlayerType { get; }

        public abstract CommandResult ExecuteCommand();    
    }
}
