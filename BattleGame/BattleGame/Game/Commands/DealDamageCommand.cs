using BattleGame.Game.Commander;
using BattleGame.Game.Commands.Calculators;
using BattleGame.Game.Commands.WeaponTriger;
using BattleGame.Game.Commands.WeaponTriger.Factory;
using BattleGame.Game.Options;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Commands
{
    public class DealDamageCommand : ICastCommand
    {
        private readonly PlayerAttackTurn _playerAttack;
        private readonly IPlayer _enemy;
        private readonly WeaponTriggerHandler _triggerHandler;
        private readonly Random _random;

        public DealDamageCommand(PlayerAttackTurn playerAttack, IPlayer enemy, WeaponTriggerHandler triggerHandler, Random random)
        {
            _playerAttack = playerAttack;
            _enemy = enemy;
            _triggerHandler = triggerHandler;
            _random = random;
        }

        public CommandResult Execute()
        {
            PlayerDefenseTurn playerDefense = new PlayerDefenseTurn() { Player = _enemy };
            CommandResult commandResult = new CommandResult() { PlayerAttackTurn = _playerAttack, PlayerDefenseTurn = playerDefense };

            if (_enemy is IWarrior enemyWarrior)
            {
                WarriorDefenceTurn warriorDefense = new WarriorDefenceTurn() { Player = _enemy };

                SelfDefensiveTriggerFactory selfDefensiveTriggerFactory = new SelfDefensiveTriggerFactory(enemyWarrior, warriorDefense);
                ISelfDefensiveTrigger selfDefensiveTrigger = selfDefensiveTriggerFactory.CreateTrigger(enemyWarrior.Weapon.Trigger);
                ExecuteTrigger(selfDefensiveTrigger, enemyWarrior);

                playerDefense.Defense = _random.Next(0, _enemy.MaxBlock);

                DefensiveTriggerFactoy defensiveTriggerFactoy = new DefensiveTriggerFactoy(warriorDefense);
                IDefensiveTrigger defensiveTrigger = defensiveTriggerFactoy.CreateTrigger(enemyWarrior.Weapon.Trigger);
                ExecuteTrigger(defensiveTrigger, enemyWarrior);
            }
            else
            {
                playerDefense.Defense = _random.Next(0, _enemy.MaxBlock);
            }

            if (_playerAttack.Value > playerDefense.Defense)
            {
                int damage = _playerAttack.Value - playerDefense.Defense;
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
