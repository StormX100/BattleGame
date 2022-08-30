using BattleGame.Game.Commands.WeaponTriger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model.Weapons
{
    public class Daedalus : IWeapon
    {
        public int TriggerChance => 30;

        WeaponsTrigger IWeapon.Trigger => WeaponsTrigger.DoubleAttack;
    }
}
