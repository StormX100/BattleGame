using BattleGame.Game.Commander;
using BattleGame.Game.Commands;
using BattleGame.Game.Commands.WeaponTriger;
using BattleGame.Game.Commands.WeaponTriger.Factory;
using BattleGame.Game.Options;
using BattleGame.Game.WeaponTrigger;
using BattleGame.Model;
using System;

namespace BattleGame.Game
{
    public class AttackCommand : IAttackCommand
    {
        private readonly WarriorAttackTurn _warriorAttack;
        private readonly IPlayer _enemy;
        private readonly IWeaponTriggerHandler _triggerHandler;
        private readonly Random _random;

        public AttackCommand(WarriorAttackTurn warriorAttack, IPlayer enemy, IWeaponTriggerHandler triggerHandler, Random random)
        {
            _warriorAttack = warriorAttack;
            _enemy = enemy;
            _triggerHandler = triggerHandler;
            _random = random;
        }

        public CommandResult Execute()
        {
            PlayerDefenseTurn playerDefense = new PlayerDefenseTurn() { Player = _enemy };
            CommandResult commandResult = new CommandResult() { PlayerAttackTurn = _warriorAttack, PlayerDefenseTurn = playerDefense };

            if (_enemy is IWarrior enemyWarrior)
            {
                WarriorDefenceTurn warriorDefenseTurn = new WarriorDefenceTurn() { Player = _enemy };

                SelfDefensiveTriggerFactory selfDefensiveTriggerFactory = new SelfDefensiveTriggerFactory(enemyWarrior, warriorDefenseTurn);
                ISelfDefensiveTrigger selfDefensiveTrigger = selfDefensiveTriggerFactory.CreateTrigger(enemyWarrior.Weapon.Trigger);
                ExecuteTrigger(selfDefensiveTrigger, enemyWarrior);

                playerDefense.Defense = _random.Next(0, _enemy.MaxBlock);

                DefensiveTriggerFactoy defensiveTriggerFactoy = new DefensiveTriggerFactoy(warriorDefenseTurn);
                IDefensiveTrigger defensiveTrigger = defensiveTriggerFactoy.CreateTrigger(enemyWarrior.Weapon.Trigger);
                ExecuteTrigger(defensiveTrigger, enemyWarrior);

                commandResult.PlayerDefenseTurn = warriorDefenseTurn;
            }
            else
            {
                playerDefense.Defense = _random.Next(0, _enemy.MaxBlock);
            }

            if (_warriorAttack.Value > playerDefense.Defense)
            {
                int damage = _warriorAttack.Value - playerDefense.Defense;
                playerDefense.DamageTaken = damage;
                _enemy.Health -= damage;
            }

            return commandResult;
        }

        private void ExecuteTrigger(IWeaponTrigger trigger, IWarrior warrior)
        {
            if (_triggerHandler.IsTriggered(trigger, warrior.Weapon.TriggerChance))
            {
                trigger.Execute();
            }
        }
    }
}
