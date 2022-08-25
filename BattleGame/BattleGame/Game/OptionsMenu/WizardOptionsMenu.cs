using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.OptionsMenu
{
    public class WizardOptionsMenu : OptionsMenu
    {
        protected override Array Types { get; set; }

        public WizardOptionsMenu()
        {
            Types = Enum.GetValues(typeof(WizardAttackTypes));
        }       
    }
}
