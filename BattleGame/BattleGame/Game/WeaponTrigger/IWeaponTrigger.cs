using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger
{
    public interface IWeaponTrigger
    {
        WeaponsTrigger Trigger { get; }

        void Execute();
    }
}
