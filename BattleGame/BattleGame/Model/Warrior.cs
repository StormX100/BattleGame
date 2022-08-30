﻿using BattleGame.Game;
using BattleGame.Game.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Model
{
    public class Warrior : Player, IWarrior
    {
        private IAttackCommand _attackCommand;

        public IWeapon Weapon { get; }
      
        public Warrior(IWeapon weapon)
        {
            Weapon = weapon;
        }   

        public override CommandResult ExecuteCommand()
        {
            return _attackCommand?.Execute();
        }

        public void SetCommand(IAttackCommand attackCommand)
        {
            _attackCommand = attackCommand;
        }
    }
}
