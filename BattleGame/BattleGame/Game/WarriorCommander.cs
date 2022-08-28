using BattleGame.Game.Options;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            switch (option)
            {
                case AllAttackTypes.Atack:
                    IAttackCommand attackCommand = new AttackCommand(_warrior, _enemy);
                    _warrior.SetCommand(attackCommand);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
