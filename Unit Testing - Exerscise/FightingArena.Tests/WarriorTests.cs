namespace FightingArena.Tests
{
    using NUnit.Framework;
	using System;

	[TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorShouldInitializeName()
        {
            string expectedName = "test";
            Warrior warrior = new Warrior(expectedName, 100, 100);

            Assert.AreEqual(expectedName, warrior.Name);
        }

        [Test]
        public void ConstructorShouldInitializeDamage()
        {
            int expectedDamage = 50;
            Warrior warrior = new Warrior("test", expectedDamage, 100);

            Assert.AreEqual(expectedDamage, warrior.Damage);
        }

        [Test]
        public void ConstructorShouldInitializeHp()
        {
            int expectedHp = 50;
            Warrior warrior = new Warrior("test", 100, expectedHp);

            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [TestCase("test")]
        [TestCase("t")]
        [TestCase("testtest")]
        public void ConstructorShouldSetValidName(string name)
        {
            Warrior warrior = new Warrior(name, 100, 100);

            string expectedName = name;
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NullEmptyOrWhiteSpaceNameShouldThrowException(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 100, 100);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(100)]
        [TestCase(50)]
        [TestCase(1)]
        public void ConstructorShouldSetValidDamage(int damage)
        {
            Warrior warrior = new Warrior("test", damage, 100);

            int expectedDamage = damage;
            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [TestCase(-50)]
        [TestCase(-1)]
        [TestCase(0)]
        public void NegativeDamageShouldThrowException(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("test", damage, 100);
            }, "Damage value should be positive!");
        }

        [TestCase(50)]
        [TestCase(10)]
        [TestCase(0)]
        public void ConstructorShouldSetValidHp(int healtPoints)
        {
            Warrior warrior = new Warrior("test", 100, healtPoints);

            int expectedHealthPoints = healtPoints;
            int actualHealthPoints = warrior.HP;

            Assert.AreEqual(expectedHealthPoints, actualHealthPoints);
        }

        [TestCase(-50)]
        [TestCase(-10)]
        [TestCase(-1)]
        public void NegativeHpShouldThrowException(int healthPoints)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("test", 100, healthPoints);
            }, "HP should not be negative!");
        }

        [TestCase(20)]
        [TestCase(30)]
        public void AttackingWarriorHavingLowHpShouldThrowException(int healthPoints)
        {
            Warrior attacking = new Warrior("test", 100, healthPoints);
            Warrior attacked = new Warrior("test2", 100, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacking.Attack(attacked);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(20)]
        [TestCase(30)]
        public void EnemyWariorWithLowHpShouldThrowException(int healthPoints)
        {
            int minAttackHp = 30;

            Warrior attacking = new Warrior("test", 100, 100);
            Warrior attacked = new Warrior("test2", 100, healthPoints);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacking.Attack(attacked);
            }, $"Enemy HP must be greater than {minAttackHp} in order to attack him!");
        }

        [TestCase(50)]
        [TestCase(60)]
        public void AttackingStrongerEnemyShouldThrowException(int healthPoints)
        {
            Warrior attacking = new Warrior("test", 100, healthPoints);
            Warrior attacked = new Warrior("test2", 100, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacking.Attack(attacking);
            }, "You are trying to attack too strong enemy");
        }

        [TestCase(30)]
        [TestCase(40)]
        public void AttackingWarriorTakesDamageFromTheEnemyWarrior(int damage)
        {
            Warrior attacking = new Warrior("test", 20, 100);
            Warrior attacked = new Warrior("test2", damage, 100);
            int expectedHealthPoints = 100 - damage;

            attacking.Attack(attacked);
            int actualHealthPoints = attacking.HP;

            Assert.AreEqual(expectedHealthPoints, actualHealthPoints);
        }

        [TestCase(40)]
        [TestCase(50)]
        public void AttackingEnemyWarriorWithEnoughDamageToKillHim(int damage)
        {
            Warrior attacking = new Warrior("test", damage, 100);
            Warrior attacked = new Warrior("test2", 10, 40);
            int expectedEnemyHp = 0;

            attacking.Attack(attacked);

            Assert.AreEqual(expectedEnemyHp, attacked.HP);
        }

        [TestCase(40)]
        [TestCase(50)]
        public void AttackingEnemyWarriorWithoutKillingHim(int damage)
        {
            Warrior attacking = new Warrior("test", damage, 100);
            Warrior attacked = new Warrior("test2", 10, 100);
            int expectedEnemyHp = 100 - damage;

            attacking.Attack(attacked);

            Assert.AreEqual(expectedEnemyHp, attacked.HP);
        }
    }
}