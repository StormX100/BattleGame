


using BattleGame.Model;
using BattleGame.Game;

using System;

namespace BattleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer firstPlayer = new Warrior() { Health = 50, MaxAttack = 10, MaxBlock = 12 };
            IPlayer secondPlayer = new Wizard() { Health = 50, MaxAttack = 10, MaxBlock = 12 };
        }
    }
}
