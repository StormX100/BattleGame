using BattleGame.Game.Commander;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger
{
    public class BonusDamageTrigger : IOffensiveTrigger
    {
        private WarriorAttackTurn _attack;

        public WeaponsTrigger Trigger => WeaponsTrigger.BonusDamage;

        public BonusDamageTrigger(WarriorAttackTurn attack)
        {
            _attack = attack;
        }

        public void Execute()
        {            
            _attack.Value += 10;
            _attack.IncreasedValue += 10;
            _attack.Trigger = WeaponsTrigger.BonusDamage;
        }
    }
}
