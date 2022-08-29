using BattleGame.Game.Commander;
using BattleGame.Game.Commands.WeaponTriger;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands.Calculators
{
    public class AttackCalculator
    {
        private readonly IWarrior _warrior;
        private readonly WeaponTriggerHandler _triggerHandler;

        public AttackCalculator(IWarrior warrior, WeaponTriggerHandler triggerHandler)
        {
            _warrior = warrior;
            _triggerHandler = triggerHandler;         
        }

        public WarriorAttack Calculate()
        {
            WarriorAttack warriorAttack = new WarriorAttack() {Trigger = WeaponTriggers.None };

            var selfOffensiveTriggerFactory = new SelfOffensiveTriggerFactory(_warrior, warriorAttack);
            var selfOffensiveTrigger = selfOffensiveTriggerFactory.CreateTrigger(_warrior.Weapon.Trigger);

            warriorAttack.Attack = _warrior.Attack();

            ExecuteTrigger(selfOffensiveTrigger);

            var offensiveTriggerFactory = new OffensiveTriggerFactory(warriorAttack);
            var offensiveTrigger = offensiveTriggerFactory.CreateTrigger(_warrior.Weapon.Trigger);

            ExecuteTrigger(offensiveTrigger);

            return warriorAttack;
        }

        private void ExecuteTrigger(IWeaponTrigger offensiveTrigger)
        {
            if (_triggerHandler.IsTriggered(offensiveTrigger, _warrior.Weapon.TriggerChance))
            {
                offensiveTrigger.Execute();
            }
        }
    }
}
