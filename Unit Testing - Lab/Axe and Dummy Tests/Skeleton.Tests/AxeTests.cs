using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Does_Weapon_Lose_Durability_After_Atack()
        {
            // Test if weapon loses durability after each attack
            //
            // · Test attacking with a broken weapon

            Axe axe = new Axe(10, 20);
            Dummy dummy = new Dummy(100, 100);
            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, 19);
        }

        [Test]
        public void Atack_With_Broken_Weapon()
        {
            Axe axe = new Axe(10, 1);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() =>
                {
                    axe.Attack(dummy);
                });
        }
    }
}
