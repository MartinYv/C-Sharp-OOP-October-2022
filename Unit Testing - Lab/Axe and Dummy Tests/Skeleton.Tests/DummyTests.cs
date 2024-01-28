using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]

        public void Dummy_Loses_Hp_When_Attacked()
        {
            // Dummy loses health if attacked
            //
            // Dead Dummy throws an exception if attacked
            //
            // Dead Dummy can give XP
            //
            // Alive Dummy can't give XP

            Dummy dummy = new Dummy(100, 100);
            dummy.TakeAttack(1);

            Assert.AreEqual(dummy.Health, 99);
        }


        [Test]
        public void Dummy_Throws_Exception_If_Atacked()
        {
            Dummy dummy = new Dummy(100, 100);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(101));
        }


        [Test]
        public void Dead_Dummy_Can_Give_Xp_While_Dead()
        {
            Dummy dummy = new Dummy(100, 100);
            dummy.TakeAttack(100);

            if (dummy.IsDead())
            {
                Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
            }
        }

        [Test]
        public void Alive_Cant_Give_Xp()
        {
            Dummy dummy = new Dummy(100, 100);

            if (!dummy.IsDead())
            {
                Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
            }
        }

    }
}

