using BattleGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model
{
    public interface IWarrior : IPlayer, IWeaponWielder
    {
        int Attack();

        void SetCommand(IAttackCommand attackCommand);
    }
}
