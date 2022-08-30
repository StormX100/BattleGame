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
        private readonly IList<AllAttackTypes> _playerAttackTypes;
        private readonly IList<AllAttackTypes> _allAttackTypes;

        public AttackTypesOptionsMenu(IPlayer player)
        {
            _player = player;
            _playerAttackTypes = AttackTypesMapping.Mapping[_player.PlayerType];
            _allAttackTypes = Enum.GetValues(typeof(AllAttackTypes)).Cast<AllAttackTypes>().ToList();
        }

        public string CreateOptions()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"\nCommands menu for { _player.Name }");

            foreach (var type in _playerAttackTypes)
            {
                builder.AppendLine("To " + type.ToString() + " press key " + (int)type);
            }

            return builder.ToString();
        }

        public bool IsOptionValid(char key)
        {
            return key - '0' >= 0 && key - '0' <= _playerAttackTypes.Count;
        }

        public AllAttackTypes GetAttackType(char key)
        {
            return _allAttackTypes.ElementAt(key - '0');
        }
    }
}
