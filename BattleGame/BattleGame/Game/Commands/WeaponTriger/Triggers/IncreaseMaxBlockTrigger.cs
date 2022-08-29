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

        public IncreaseMaxBlockTrigger(IPlayer player)
        {
            _player = player;
        }

        public WeaponTriggers Trigger => WeaponTriggers.IncreaseMaxBlock;

        public void Execute()
        {
            _player.MaxBlock += 10;
        }
    }
}
