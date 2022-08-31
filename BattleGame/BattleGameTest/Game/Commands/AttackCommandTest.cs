using BattleGame.Game;
using BattleGame.Game.Commands;
using BattleGame.Game.Commands.WeaponTriger;
using BattleGame.Game.Options;
using BattleGame.Game.WeaponTrigger;
using BattleGame.Model;
using FakeItEasy;
using NUnit.Framework;
using System;

namespace BattleGameTest.Game.Commands
{
    [TestFixture]
    public class AttackCommandTest
    {
        private WarriorAttackTurn _wariorAttackTurn;
        private AttackCommand _attackCommand;
        private AttackCommand _warriorAttackCommand;
        private IPlayer _enemy;
        private IWeapon _enemyWarriorWeapon;
        private IWarrior _enemyWarrior;
        private IWeaponTriggerHandler _weaponTriggerHandler;
        private Random _random;

        [SetUp]
        public void SetUp()
        {
            _wariorAttackTurn = new WarriorAttackTurn() { Action = AllAttackTypes.Atack, Value = 10 };
            _enemy = new Wizard() { Health = 19, MaxBlock = 5 };

            _enemyWarriorWeapon = A.Fake<IWeapon>();
            _enemyWarrior = new Warrior() { Weapon = _enemyWarriorWeapon, MaxBlock  = 12};

            _weaponTriggerHandler = A.Fake<IWeaponTriggerHandler>();
            _random = A.Fake<Random>();

            _attackCommand = new AttackCommand(_wariorAttackTurn, _enemy, _weaponTriggerHandler, _random);
            _warriorAttackCommand = new AttackCommand(_wariorAttackTurn, _enemyWarrior, _weaponTriggerHandler, _random);
        }

        [Test]
        public void CommandShouldCalculateEnemyDefense()
        {
            // act
            _attackCommand.Execute();

            // assert
            A.CallTo(() => _random.Next(0, 5)).MustHaveHappened();
        }

        [Test]
        public void CommandShouldDealDamageToEnemy()
        {
            // arrange
            A.CallTo(() => _random.Next(0, 5)).Returns(5);

            // act
            _attackCommand.Execute();

            //assert
            Assert.That(_enemy.Health, Is.EqualTo(14));
        }
        [Test]
        public void CommandShouldNotDealDamageToEnemy()
        {
            // arrange
            A.CallTo(() => _random.Next(0, 5)).Returns(50);

            // act
            _attackCommand.Execute();

            //assert
            Assert.That(_enemy.Health, Is.EqualTo(19));
        }

        [Test]
        public void CommandShouldTriggerIncreaseMaxBlock()
        {
            // arrange
            A.CallTo(() => _enemyWarriorWeapon.Trigger).Returns(WeaponsTrigger.IncreaseMaxBlock);

            A.CallTo(() => _weaponTriggerHandler.IsTriggered(A<IncreaseMaxBlockTrigger>._, A<int>._)).Returns(true);
            A.CallTo(() => _weaponTriggerHandler.IsTriggered(A<IDefensiveTrigger>._, A<int>._)).Returns(false);

            // act
            _warriorAttackCommand.Execute();

            //assert
            Assert.That(_enemyWarrior.MaxBlock, Is.EqualTo(32));
            Assert.That(_enemyWarrior.MinBlock, Is.EqualTo(20));
        }

        [Test]
        public void CommandShouldTriggerEvadeAttack()
        {
            // arrange
            A.CallTo(() => _enemyWarriorWeapon.Trigger).Returns(WeaponsTrigger.EvadeAttack);

            A.CallTo(() => _weaponTriggerHandler.IsTriggered(A<EvadeAttackTrigger>._, A<int>._)).Returns(true);
            A.CallTo(() => _weaponTriggerHandler.IsTriggered(A<ISelfDefensiveTrigger>._, A<int>._)).Returns(false);

            // act
            var commandResult = _warriorAttackCommand.Execute();

            //assert
            Assert.That(commandResult.PlayerDefenseTurn.DamageTaken, Is.EqualTo(0));
            Assert.That(commandResult.PlayerDefenseTurn.Defense, Is.EqualTo(int.MaxValue));
        }

        [Test]
        public void CommandShouldSetCommandResultForPlayer()
        {
            // arrange
            A.CallTo(() => _random.Next(0, 5)).Returns(5);

            // act
            var commandResult =_attackCommand.Execute();

            // assert
            Assert.That(commandResult.PlayerAttackTurn, Is.EqualTo(_wariorAttackTurn));
            Assert.That(commandResult.PlayerDefenseTurn.Defense, Is.EqualTo(5));
            Assert.That(commandResult.PlayerDefenseTurn.Player, Is.EqualTo(_enemy));
            Assert.That(commandResult.PlayerDefenseTurn.DamageTaken, Is.EqualTo(5));          
        }

        [Test]
        public void CommandShouldSetCommandResultForWarrior()
        {
            // arrange
            A.CallTo(() => _random.Next(0, 5)).Returns(5);
            A.CallTo(() => _enemyWarriorWeapon.Trigger).Returns(WeaponsTrigger.IncreaseMaxBlock);
            A.CallTo(() => _weaponTriggerHandler.IsTriggered(A<IncreaseMaxBlockTrigger>._, A<int>._)).Returns(true);
            A.CallTo(() => _weaponTriggerHandler.IsTriggered(A<IDefensiveTrigger>._, A<int>._)).Returns(false);

            // act
            var commandResult = _warriorAttackCommand.Execute();

            // assert
            Assert.That(commandResult.PlayerDefenseTurn, Is.TypeOf<WarriorDefenceTurn>());
            var warriorDefenceTurn = (WarriorDefenceTurn)commandResult.PlayerDefenseTurn;

            Assert.That(warriorDefenceTurn.Trigger, Is.EqualTo(WeaponsTrigger.IncreaseMaxBlock));
            Assert.That(warriorDefenceTurn.IncreasedValue, Is.EqualTo(20));
        }
    }
}
