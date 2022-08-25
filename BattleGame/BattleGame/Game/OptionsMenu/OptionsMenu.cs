using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.OptionsMenu
{
    public abstract class OptionsMenu
    {
        protected abstract Array Types { get; set; }

        public string CreateOption()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Commands menu");
           
            foreach (var type in Types)
            {
                builder.AppendLine("To " + type.ToString() + " press key " + (int)type);
            }

            return builder.ToString();
        }

        public bool IsChosenOptionValid(int option)
        {
            return option >= 0 && option < Types.Length;
        }
    }
}
