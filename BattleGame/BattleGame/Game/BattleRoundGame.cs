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
                AllAttackTypes firstPlayerOption = ReadOption(FirstPlayer);
                Turn firstPlayeTurn = new Turn(FirstPlayer, SecondPlayer, firstPlayerOption);
                firstPlayeTurn.Start();

                AllAttackTypes secondPlayerOption = ReadOption(SecondPlayer);
                Turn secondPlayeTurn = new Turn(SecondPlayer, FirstPlayer, secondPlayerOption);
                secondPlayeTurn.Start();
            }
        }

        private AllAttackTypes ReadOption(IPlayer player)
        {
            var attackTypeOptions = new AttackTypesOptionsMenu(player);
            char key;

            do
            {
                Console.WriteLine(attackTypeOptions.CreateOptions());
                key = Console.ReadKey().KeyChar;                
            }
            while (!attackTypeOptions.IsOptionValid(key));
            AllAttackTypes option = attackTypeOptions.GetAttackType(key);

            return option;
        }
    }
}
