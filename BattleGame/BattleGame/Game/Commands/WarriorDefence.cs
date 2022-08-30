using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    public class WarriorDefence : PlayerDefenseTurn
    {
        public WeaponsTrigger Trigger;

        public int IncreasedValue { get; set; }
    }
}
