using BattleGame.Game.Commander;
using BattleGame.Game.Commands;
using BattleGame.Game.Commands.Calculators;
using BattleGame.Game.Commands.WeaponTriger;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game
{
    public class CommandFactoyCreator
    {
        public static IPlayerCommander GetCommandFactory(IPlayer player, IPlayer enemy)
        {
            switch (player.PlayerType)
            {
                case PlayerType.Warrior:
                    var triggerHandler = new WeaponTriggerHandler();
                    return new WarriorCommander((IWarrior)player, enemy, new AttackCalculator((IWarrior)player, triggerHandler));
                case PlayerType.Wizard:
                    return new WizardCommander((IWizard)player, enemy);
                default:
                    return null;
            }
        }
    }
}
