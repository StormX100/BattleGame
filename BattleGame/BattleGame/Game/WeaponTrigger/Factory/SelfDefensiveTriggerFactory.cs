using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.WeaponTriger.Factory
{
    public class SelfDefensiveTriggerFactory
    {
        private readonly IWarrior _warrior;
        private readonly WarriorDefence _warriorDefense;

        public SelfDefensiveTriggerFactory(IWarrior warrior, WarriorDefence warriorDefense)
        {
            _warrior = warrior;
            _warriorDefense = warriorDefense;
        }

        public ISelfDefensiveTrigger CreateTrigger(WeaponsTrigger weaponTrigger)
        {
            switch (weaponTrigger)
            {
                case WeaponsTrigger.IncreaseMaxBlock:
                    return new IncreaseMaxBlockTrigger(_warrior, _warriorDefense);
                default:
                    return null;
            }
        }
    }
}
