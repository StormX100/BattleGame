using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    public class DealDamageCommand : ICommand
    {
        public DealDamageCommand(IWizard wizard, IPlayer enemy)
        {          
        }

        public void Execute()
        {
        }
    }
}
