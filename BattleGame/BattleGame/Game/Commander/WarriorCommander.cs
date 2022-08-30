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

        public WarriorCommander(IWarrior warrior, IPlayer enemy)
        {
            _warrior = warrior;
            _enemy = enemy;            
        }

        public void SetCommand(AllAttackTypes option)
        {  
            var weaponTriggerHandle = new WeaponTriggerHandler();
            var random = new Random();

            switch (option)
            {
                case AllAttackTypes.Atack:
                    var warriorAttack = new AttackCalculator(_warrior, weaponTriggerHandle, random).Calculate();
                    IAttackCommand attackCommand = new AttackCommand(warriorAttack, _enemy, weaponTriggerHandle, random);
                    _warrior.SetCommand(attackCommand);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
