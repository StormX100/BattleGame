using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commander
{
    public class WarriorAttack
    {
        public int Attack { get; set; }

        public int IncreasedValue { get; set; }

        public WeaponTriggers Trigger { get; set; }
    }
}
