using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  BattleGame.Game.Commands;
using BattleGame.Model;
using BattleGame.Game.Commander;

namespace BattleGameTest.Game.Commands
{
    [TestFixture]
    public class IncreaseMaxAttackCommandTest
    {
        private IWizard _wizard;
        private IWarrior _enemy;
        private ICastCommand _increaseMaxBlockCommand;
        private PlayerAttackTurn _playerAttackTurn;


        [SetUp]
        public void SetUp()
        {
            _wizard = new Wizard() { MaxAttack = 10 };
            _enemy = new Warrior();
            _playerAttackTurn = new PlayerAttackTurn() { Value = 10 };

            _increaseMaxBlockCommand = new IncreaseMaxAttackCommand(_playerAttackTurn , _wizard, _enemy);
        }

        [Test]
        public void CommandShouldIncreaseMaxAttack()
        {
            // act
            _increaseMaxBlockCommand.Execute();

            // assert
            Assert.That(_wizard.MaxAttack, Is.EqualTo(20));
        }

        [Test]
        public void CommandShouldSetCommandesult()
        {
            // act
            var commandResult = _increaseMaxBlockCommand.Execute();

            // assert
            Assert.That(commandResult.PlayerAttackTurn.Equals(_playerAttackTurn));
            Assert.That(commandResult.PlayerDefenseTurn.Player.Equals(_enemy));

        }
    }
}
