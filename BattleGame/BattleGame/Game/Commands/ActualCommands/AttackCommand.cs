using BattleGame.Game.Commander;
using BattleGame.Game.Commands;
using BattleGame.Game.Commands.WeaponTriger;
using BattleGame.Game.Commands.WeaponTriger.Factory;
using BattleGame.Model;

namespace BattleGame.Game
{
    public class AttackCommand : IAttackCommand
    {
        private readonly WarriorAttack _attack;
        private readonly IPlayer _enemy;
        private readonly WeaponTriggerHandler _triggerHandler;

        public AttackCommand(WarriorAttack attack, IPlayer enemy, WeaponTriggerHandler triggerHandler)
        {
            _attack = attack;
            _enemy = enemy;
            _triggerHandler = triggerHandler;
        }

        public CommandResult Execute()
        {
            if(_enemy is IWarrior enemyWarrior)
            {
                SelfDefensiveTriggerFactory selfDefensiveTriggerFactory = new SelfDefensiveTriggerFactory(enemyWarrior);
                ISelfDefensiveTrigger selfDefensiveTrigger = selfDefensiveTriggerFactory.CreateTrigger(enemyWarrior.Weapon.Trigger);
                ExecuteTrigger(selfDefensiveTrigger, enemyWarrior);
            }

            if (_attack.Attack > _enemy.MaxBlock)
            {
                _enemy.Health = _attack.Attack - _enemy.MaxBlock;
            }

            return new CommandResult();
        }

        private void ExecuteTrigger(ISelfDefensiveTrigger offensiveTrigger, IWarrior warrior)
        {
            if (_triggerHandler.IsTriggered(offensiveTrigger, warrior.Weapon.TriggerChance))
            {
                offensiveTrigger.Execute();
            }
        }
    }
}
