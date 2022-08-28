using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game
{
    public class CommandFactoyCreator
    {
        public static IPlayerCommander GetCommandFactory(IPlayer player, IPlayer enemy)
        {
            switch (player.PlayerType)
            {
                case PlayerType.Warrior:
                    return new WarriorCommander((IWarrior)player, enemy);
                case PlayerType.Wizard:
                    return new IWizardCommander((IWizard)player, enemy);
                default:
                    return null;
            }
        }
    }
}
