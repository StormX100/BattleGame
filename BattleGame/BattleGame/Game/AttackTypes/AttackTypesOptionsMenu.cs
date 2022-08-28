using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Options
{
    public class AttackTypesOptionsMenu
    {
        private readonly IPlayer _player;
        private readonly IList<AllAttackTypes> _attackTypes;

        public AttackTypesOptionsMenu(IPlayer player)
        {
            _player = player;
            _attackTypes = AttackTypesMapping.Mapping[_player.PlayerType];
        }

        public string CreateOptions()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"\nCommands menu for { _player.Name }");

            foreach (var type in _attackTypes)
            {
                builder.AppendLine("To " + type.ToString() + " press key " + (int)type);
            }

            return builder.ToString();
        }

        public bool IsOptionValid(char key)
        {
            return key - '0' >= 0 && key - '0' <= _attackTypes.Count;
        }

        public AllAttackTypes GetAttackType(char key)
        {
            return _attackTypes.ElementAt(key - '0');
        }
    }
}
