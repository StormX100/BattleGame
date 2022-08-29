using BattleGame.Game.Commander;
using BattleGame.Game.Commands;
using BattleGame.Game.Commands.Calculators;
using BattleGame.Game.Options;
using BattleGame.Model;
using System;

namespace BattleGame.Game
{
    class WarriorCommander : IPlayerCommander
    {
        private readonly IWarrior _warrior;
        private readonly IPlayer _enemy;
        private readonly AttackCalculator _attackCalculator;

        public WarriorCommander(IWarrior warrior, IPlayer enemy, AttackCalculator attackCalculator)
        {
            _warrior = warrior;
            _enemy = enemy;
            _attackCalculator = attackCalculator; 
        }

        public void SetCommand(AllAttackTypes option)
        {
            switch (option)
            {
                case AllAttackTypes.Atack:
                    var attack = _attackCalculator.Calculate();
                    IAttackCommand attackCommand = new AttackCommand(attack, _enemy, new WeaponTriggerHandler());
                    _warrior.SetCommand(attackCommand);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
