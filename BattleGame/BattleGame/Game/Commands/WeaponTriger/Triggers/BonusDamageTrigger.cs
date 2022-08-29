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
        private WarriorAttack _attack;

        public WeaponTriggers Trigger => WeaponTriggers.BonusDamage;

        public BonusDamageTrigger(WarriorAttack attack)
        {
            _attack = attack;
        }

        public void Execute()
        {            
            _attack.Attack += 10;
            _attack.IncreasedValue += 10;
            _attack.Trigger = WeaponTriggers.BonusDamage;
        }
    }
}
