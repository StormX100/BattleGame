using BattleGame.Game.Commands;
using BattleGame.Game.Options;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game
{
    public class Turn
    {
        private readonly AllAttackTypes _attackType;

        private IPlayer _player;
        private IPlayer _enemy;

        public Turn(IPlayer firstPlayer, IPlayer secondPlayer, AllAttackTypes attackType)
        {
            _player = firstPlayer;
            _enemy = secondPlayer;
            _attackType = attackType;
        }

        public TurnResult Start()
        {
            IPlayerCommander commander = CommandFactoyCreator.GetCommandFactory(_player, _enemy);
            commander.SetCommand(_attackType);

            return new TurnResult();
        }        
    }
}
