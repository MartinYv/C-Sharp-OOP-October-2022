namespace FightingArena.Tests
{
    using NUnit.Framework;
	using System;
	using System.Linq;

	[TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ConstructorShouldInitializeArena()
        {
            
            Arena constructorArena = new Arena();

            Assert.IsNotNull(constructorArena.Warriors);
        }

        [Test]
        public void ArenaReturnsTheCountOfWarriorsInIt()
        {

            for (int i = 0; i < 5; i++)
            {
                Warrior warrior = new Warrior($"ddd{i}", 10, 10);

                arena.Enroll(warrior);
            }

            Assert.AreEqual(5, arena.Warriors.Count);
        }

        [Test]
        public void EnrollNonExistingWarriorShouldSucceed()
        {
            Warrior warrior = new Warrior("test", 100, 100);

            arena.Enroll(warrior);

            Assert.IsTrue(arena.Warriors.Contains(warrior));
        }

        [Test]
        public void EnrollExistingWarriorShouldThrowException()
        {
            Warrior warrior = new Warrior("test", 100, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void EnrollWarriorWithTheSameNameShouldThrowException()
        {

            Warrior warrior1 = new Warrior("asdasd", 50, 100);
            Warrior warrior2 = new Warrior("asdasddd", 20, 99);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior1);
                arena.Enroll(warrior2);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void BothWarriorsExistInArenaWhenFighting()
        {

            Warrior warrior1 = new Warrior("test1", 20, 100);
            Warrior warrior2 = new Warrior("test2", 30, 100);

            int expectedWarrior1Hp = warrior1.HP - warrior2.Damage;
            int expectedWarrior2Hp = warrior2.HP - warrior1.Damage;

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            arena.Fight(warrior1.Name, warrior2.Name);

            Assert.AreEqual(expectedWarrior1Hp, warrior1.HP);
            Assert.AreEqual(expectedWarrior2Hp, warrior2.HP);
        }

        [TestCase("test1")]
        [TestCase("test2")]
        public void AttackingWarriorIsNotEnrolledWhenFightingThrowsException(string name)
        {
            Warrior warrior = new Warrior("Pesho", 100, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(name, warrior.Name);
            }, $"There is no fighter with name {name} enrolled for the fights!");
        }

        [TestCase("test1")]
        [TestCase("test2")]
        public void DefendingWarriorIsNotEnrolledWhenFightingThrowsException(string name)
        {
            
            Warrior warrior = new Warrior("Pesho", 100, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(warrior.Name, name);
            }, $"There is no fighter with name {name} enrolled for the fights!");
        }
    }
}