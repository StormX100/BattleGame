﻿


using BattleGame.Model;
using BattleGame.Game;

using System;
using BattleGame.Model.Weapons;

namespace BattleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer firstPlayer = new Warrior(new Daedalus()) { Name = "Radu", PlayerType = PlayerType.Warrior, Health = 50, MaxAttack = 10, MaxBlock = 12 };
            IPlayer secondPlayer = new Wizard() { Name = "Storm", PlayerType = PlayerType.Wizard, Health = 50, MaxAttack = 10, MaxBlock = 12 };

            BattleRoundGame game = new BattleRoundGame(firstPlayer, secondPlayer);
            game.StartGame();
        }
    }
}
