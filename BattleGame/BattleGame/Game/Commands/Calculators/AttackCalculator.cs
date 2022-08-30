using BattleGame.Game.Commander;
using BattleGame.Game.Commands.WeaponTriger;
using BattleGame.Game.Options;
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
        private readonly Random _random;

        public AttackCalculator(IWarrior warrior, WeaponTriggerHandler triggerHandler, Random random)
        {
            _warrior = warrior;
            _triggerHandler = triggerHandler;
            _random = random;
        }

        public WarriorAttackTurn Calculate()
        {
            WarriorAttackTurn warriorAttack = new WarriorAttackTurn() { Player = _warrior, Action = AllAttackTypes.Atack };

            var selfOffensiveTriggerFactory = new SelfOffensiveTriggerFactory(_warrior, warriorAttack);
            var selfOffensiveTrigger = selfOffensiveTriggerFactory.CreateTrigger(_warrior.Weapon.Trigger);
            ExecuteTrigger(selfOffensiveTrigger);

            warriorAttack.Value = _random.Next(_warrior.MinAttack, _warrior.MaxAttack);            

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
