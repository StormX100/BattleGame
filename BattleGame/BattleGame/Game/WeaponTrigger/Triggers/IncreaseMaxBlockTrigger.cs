using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger
{
    public class IncreaseMaxBlockTrigger : ISelfDefensiveTrigger
    {
        private readonly IPlayer _player;
        private readonly WarriorDefence _warriorDefense;

        public IncreaseMaxBlockTrigger(IPlayer player, WarriorDefence warriorDefense)
        {
            _player = player;
            _warriorDefense = warriorDefense;
        }

        public WeaponsTrigger Trigger => WeaponsTrigger.IncreaseMaxBlock;

        public void Execute()
        {
            var increasedMaxBlock = 20;

            _player.MaxBlock += increasedMaxBlock;
            _player.MinBlock += increasedMaxBlock;
            _warriorDefense.IncreasedValue = increasedMaxBlock;
            _warriorDefense.Trigger = WeaponsTrigger.IncreaseMaxBlock;
        }
    }
}
