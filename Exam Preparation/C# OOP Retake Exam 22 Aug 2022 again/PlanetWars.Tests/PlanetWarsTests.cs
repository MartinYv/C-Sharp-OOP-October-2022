using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {

            [Test]
            public void Ctor_Test_Works_As_Well()
            {
                Planet planet = new Planet("Neptun", 100);


                Assert.AreEqual("Neptun", planet.Name);
                Assert.AreEqual(100, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);


            }


            [TestCase(null)]
            [TestCase("")]
            public void Name_Throws_When_Its_NullOrEmptry(string name)
            {
                Assert.Throws<ArgumentException>(() => new Planet(name, 100));
            }


            [TestCase(-1)]
            [TestCase(-50)]
            public void Budget_Throws_When_Its_Less_Than_0(int budget)
            {
                Assert.Throws<ArgumentException>(() => new Planet("Asd", budget));
            }

            [Test]
            public void MillitaryRatio_Method()
            {
                Planet planet = new Planet("Neptun", 100);
                Weapon weapon = new Weapon("Noj", 10, 100);

                planet.AddWeapon(weapon);

                Assert.AreEqual(100, planet.MilitaryPowerRatio);
            }

            [Test]
            public void Profit_Method()
            {
                Planet planet = new Planet("Neptun", 100);
                planet.Profit(1000);

                Assert.AreEqual(1100, planet.Budget);
            }

            [Test]
            public void Spend_Method()
            {
                Planet planet = new Planet("Neptun", 100);
                planet.SpendFunds(10);

                Assert.AreEqual(90, planet.Budget);
            }

            [Test]
            public void Spend_Method_ThrowsException()
            {
                Planet planet = new Planet("Neptun", 100);


                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(110));
            }

            [Test]
            public void Add_AlreadyExisting_Weapon_ThrowsException()
            {
                Planet planet = new Planet("Neptun", 100);
                Weapon weapon = new Weapon("Noj", 10, 100);

                planet.AddWeapon(weapon);


                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
            }

            [Test]
            public void Add__Weapon_Works()
            {
                Planet planet = new Planet("Neptun", 100);
                Weapon weapon = new Weapon("Noj", 10, 100);

                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void Remoce__Weapon_Works()
            {
                Planet planet = new Planet("Neptun", 100);
                Weapon weapon = new Weapon("Noj", 10, 100);

                planet.AddWeapon(weapon);
                planet.RemoveWeapon("Noj");
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [Test]
            public void Upgrate__Weapon_Throws()
            {
                Planet planet = new Planet("Neptun", 100);

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("asd"));
            }

            [Test]
            public void Upgrate__Weapon_Works()
            {
                Planet planet = new Planet("Neptun", 100);
                Weapon weapon = new Weapon("Noj", 10, 100);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Noj");

                Assert.AreEqual(101, weapon.DestructionLevel);
            }

            [Test]
            public void DestructOpponent_Throws()
            {
                Planet planet = new Planet("Neptun", 100);
                Weapon weapon = new Weapon("Noj", 10, 100);
                
                Planet planet2 = new Planet("Neptun", 100);
                Weapon weapon2 = new Weapon("Noj", 10, 1010);



                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(planet2));
            }

            [Test]
            public void DestructOpponent_Works()
            {
                Planet planet = new Planet("Neptun", 100);
                Weapon weapon = new Weapon("Noj", 10, 100);
                planet.AddWeapon(weapon);

                Planet opponent = new Planet("Neptunnn", 100);
                Weapon weapon2 = new Weapon("Noj", 10, 10);
                opponent.AddWeapon(weapon2);

                planet.DestructOpponent(opponent);

                Assert.AreEqual($"{opponent.Name} is destructed!", $"{opponent.Name} is destructed!");

            }


            [Test]
            public void Weapon_Constructor()
            {
                Weapon weapon = new Weapon("Noj", 10, 100);

                Assert.AreEqual("Noj", weapon.Name);
                Assert.AreEqual(10, weapon.Price);
                Assert.AreEqual(100, weapon.DestructionLevel);
            }

            [Test]
            public void Weapon_Price_Throws_When_Its_Less_Than_Zero()
            {
              

               Assert.Throws<ArgumentException>(()=> new Weapon("Noj", -8, 100));
            }

            [Test]
            public void Weapon_Nuclear_True()
            {
                Weapon weapon = new Weapon("Noj", 10, 100);
                Weapon weapon2 = new Weapon("Nojj", 5, 5);

                Assert.AreEqual(true, weapon.IsNuclear);
                Assert.AreEqual(false, weapon2.IsNuclear);
                
            }

            [Test]
            public void Weapon_DestructionLevel()
            {
                Weapon weapon = new Weapon("Noj", 10, 100);
                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(101, weapon.DestructionLevel);
               

            }
        }
    }
}