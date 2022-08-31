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
            while (FirstPlayer.Health > 0 && SecondPlayer.Health > 0)
            {
                AllAttackTypes firstPlayerOption = ReadOption(FirstPlayer);
                Turn firstPlayeTurn = new Turn(FirstPlayer, SecondPlayer, firstPlayerOption);
                CommandResult firstPlayerCommandResult = firstPlayeTurn.Start();

                AllAttackTypes secondPlayerOption = ReadOption(SecondPlayer);
                Turn secondPlayeTurn = new Turn(SecondPlayer, FirstPlayer, secondPlayerOption);
                CommandResult secondPlayerCommandResult = secondPlayeTurn.Start();

                Console.WriteLine(GetCommandResult(firstPlayerCommandResult));
                Console.WriteLine(GetCommandResult(secondPlayerCommandResult));

                Console.WriteLine("\nPlayer " + FirstPlayer.Name + " Health " + FirstPlayer.Health);
                Console.WriteLine("\nPlayer " + SecondPlayer.Name + " Health " + SecondPlayer.Health);
            }
        }

        private string GetCommandResult(CommandResult commandResult)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var playerAttackTurn = commandResult.PlayerAttackTurn;
            stringBuilder.Append("\nPlayer " + playerAttackTurn.Player.Name + " used " + playerAttackTurn.Value + " " + playerAttackTurn.Action);
            if (commandResult.PlayerAttackTurn is WarriorAttackTurn warriorAttackTurn)
            {
                stringBuilder.Append("\nWeapon trigger " + warriorAttackTurn.Trigger + " increased value " + warriorAttackTurn.IncreasedValue);
            }

            stringBuilder.AppendLine();

            var playerDefenceTurn = commandResult.PlayerDefenseTurn;
            stringBuilder.Append("\nPlayer " + playerDefenceTurn.Player.Name + " defended himself with " + playerDefenceTurn.Defense);
            stringBuilder.Append(", resulting in taking " + playerDefenceTurn.DamageTaken + " damage");          

            return stringBuilder.ToString();
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
