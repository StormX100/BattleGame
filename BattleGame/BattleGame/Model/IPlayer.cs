using BattleGame.Game;
using BattleGame.Game.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BattleGame.Model
{
    public interface IPlayer
    {
        string Name { get; set; }

        int Health { get; set; }

        int MaxAttack { get; set; }

        int MaxBlock { get; set; }

        int MinAttack { get; set; }

        int MinBlock { get; set; }

        PlayerType PlayerType { get; }

        CommandResult ExecuteCommand();
    }
}
