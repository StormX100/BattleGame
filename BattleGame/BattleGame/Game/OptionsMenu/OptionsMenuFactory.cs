using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.OptionsMenu
{
    public class OptionsMenuFactory
    {
        public static OptionsMenu CreateOptionsMenu(IPlayer player)
        {
            switch(player.PlayerType)
            {
                case PlayerType.Warrior:
                    return new WarriorOptionsMenu();
                case PlayerType.Wizard:
                    return new WizardOptionsMenu();
                default:
                    return null;
            }
                
        }
    }
}
