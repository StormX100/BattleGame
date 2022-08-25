using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.OptionsMenu
{
    public class WarriorOptionsMenu : OptionsMenu
    {
        protected override Array Types { get; set; }

        public WarriorOptionsMenu()
        {
            Types = Enum.GetValues(typeof(WarriorAttackTypes));
        }
    }
}
