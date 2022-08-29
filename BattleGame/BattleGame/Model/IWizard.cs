﻿using BattleGame.Game.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model
{
    public interface IWizard : IPlayer
    {
        int DealDamage();

        void SetCommand(ICastCommand castCommand);
    }
}
