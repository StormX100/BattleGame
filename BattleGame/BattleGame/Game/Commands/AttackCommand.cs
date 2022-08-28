using BattleGame.Game.Commands;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game
{
    public class AttackCommand : IAttackCommand
    {
        private readonly IPlayer _enemy;
        private readonly IWarrior _warrior;

        public AttackCommand(IWarrior warrior, IPlayer enemy)
        {
            _enemy = enemy;
            _warrior = warrior;
        }

        public CommandResult Execute()
        {
            return new CommandResult();
        }
    }
}
