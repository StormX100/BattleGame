using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    class IncreaseMaxBlockCommand : ICastCommand
    {
        public IncreaseMaxBlockCommand(IWizard player)
        {
        }

        public CommandResult Execute()
        {
            return new CommandResult();
        }
    }
}
