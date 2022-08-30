using BattleGame.Game.Commander;
using BattleGame.Game.Commands;
using BattleGame.Game.Commands.Calculators;
using BattleGame.Game.Options;
using BattleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game
{
    class WizardCommander : IPlayerCommander
    {
        private readonly IWizard _wizard;
        private readonly IPlayer _enemy;

        public WizardCommander(IWizard wizard, IPlayer enemy)
        {
            _wizard = wizard;
            _enemy = enemy;
        }

        public void SetCommand(AllAttackTypes option)
        {
            var weaponTriggerHandle = new WeaponTriggerHandler();
            var random = new Random();
            PlayerAttackTurn playerAttackTurn = null;

            switch (option)
            {
                case AllAttackTypes.DealDamage:
                    playerAttackTurn = new DealDamageCalculator(_wizard, random).Calculate();
                    ICastCommand dealDamageCommand = new DealDamageCommand(playerAttackTurn, _enemy, weaponTriggerHandle, random);
                    _wizard.SetCommand(dealDamageCommand);
                    break;
                case AllAttackTypes.RestoreHealth:
                    playerAttackTurn = new RestoreHealthCalculator(_wizard, random).Calculate();
                    ICastCommand restoreHealthCommand = new RestoreHealthCommand(playerAttackTurn, _wizard);
                    _wizard.SetCommand(restoreHealthCommand);
                    break;
                case AllAttackTypes.IncreaseMaxAttack:
                    playerAttackTurn = new IncreaseMaxAttackCalculator(_wizard, random).Calculate();
                    ICastCommand increaseMaxAttackCommand = new IncreaseMaxAttackCommand(playerAttackTurn, _wizard);
                    _wizard.SetCommand(increaseMaxAttackCommand);
                    break;
                case AllAttackTypes.IncreaseMaxBlock:
                    playerAttackTurn = new InceraseMaxBlockCalculator(_wizard, random).Calculate();
                    ICastCommand increaseMaxBlockCommand = new IncreaseMaxBlockCommand(playerAttackTurn ,_wizard);
                    _wizard.SetCommand(increaseMaxBlockCommand);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
