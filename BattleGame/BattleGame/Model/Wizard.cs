using BattleGame.Game;
using BattleGame.Game.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model
{
    public class Wizard : Player, IWizard
    {
        private ICommand _castCommand;

        public void SetCommand(ICastCommand castCommand)
        {
            _castCommand = castCommand;
        }  

        public override CommandResult ExecuteCommand()
        {
            return _castCommand?.Execute();
        }
    }
}
