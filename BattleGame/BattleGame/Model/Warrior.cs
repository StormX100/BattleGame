using BattleGame.Game;
using BattleGame.Game.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model
{
    public class Warrior : IWarrior
    {
        private IAttackCommand _attackCommand;

        public string Name { get; set; }

        public int Health { get; set; }

        public int MaxAttack { get; set; }

        public int MaxBlock { get; set; }

        public PlayerType PlayerType { get; set; }

        public void SetCommand(IAttackCommand attackCommand)
        {
            _attackCommand = attackCommand;
        }

        public CommandResult ExecuteCommand()
        {
            return _attackCommand?.Execute();
        }
    }
}
