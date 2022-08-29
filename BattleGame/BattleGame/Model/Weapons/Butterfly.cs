﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model.Weapons
{
    class Butterfly : IWeapon
    {
        public WeaponTriggers Trigger => WeaponTriggers.EvadeAttack;

        public int TriggerChance => 30;
    }
}
