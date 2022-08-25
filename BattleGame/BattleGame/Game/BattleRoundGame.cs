using BattleGame.Game.Commands;
using BattleGame.Game.OptionsMenu;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game
{
    public class BattleRoundGame
    {
        public IPlayer FirstPlayer { get; }
        public IPlayer SecondPlayer { get; }

        public BattleRoundGame(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;           
        }

        public void StartGame()
        {
            while(FirstPlayer.Health > 0 && SecondPlayer.Health > 0)
            {
                int option = ReadOption(FirstPlayer);
                Turn firstPlayerTurn = new Turn(FirstPlayer, SecondPlayer, option);

                option = ReadOption(SecondPlayer);
                Turn SecondPlayerTurn = new Turn(SecondPlayer, FirstPlayer, option);
            }
        }

        private int ReadOption(IPlayer player)
        {
            var options = OptionsMenuFactory.CreateOptionsMenu(player);

            char key;
            do
            {
                Console.WriteLine(options.CreateOption());
                key = Console.ReadKey().KeyChar;
            }
            while (!options.IsChosenOptionValid(key - '0'));

            return key - '0';
        }
    }
}
