using BattleGame.Game.Commander;
using BattleGame.Game.Commands.WeaponTriger;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    public class WarriorAttackTurn : PlayerAttackTurn
    {
        public int IncreasedValue { get; set; }

        public WeaponsTrigger Trigger { get; set; }
    }
}
