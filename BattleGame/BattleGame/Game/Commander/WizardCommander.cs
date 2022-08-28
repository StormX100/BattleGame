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
            switch (option)
            {
                case AllAttackTypes.DealDamage:
                    ICastCommand dealDamageCommand = new DealDamageCommand(_wizard, _enemy, new DealDamageCalculator(_wizard));
                    _wizard.SetCommand(dealDamageCommand);
                    break;
                case AllAttackTypes.RestoreHealth:
                    ICastCommand restoreHealthCommand = new RestoreHealthCommand(_wizard, new RestoreHealthCalculator(_wizard));
                    _wizard.SetCommand(restoreHealthCommand);
                    break;
                case AllAttackTypes.IncreaseMaxAttack:
                    ICastCommand increaseMaxAttackCommand = new IncreaseMaxAttackCommand(_wizard, new IncreaseMaxAttackCalculator(_wizard));
                    _wizard.SetCommand(increaseMaxAttackCommand);
                    break;
                case AllAttackTypes.IncreaseMaxBlock:
                    ICastCommand increaseMaxBlockCommand = new IncreaseMaxBlockCommand(_wizard, new InceraseMaxBlockCalculator(_wizard));
                    _wizard.SetCommand(increaseMaxBlockCommand);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
