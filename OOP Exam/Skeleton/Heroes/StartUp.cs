using Heroes.Core;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using System.Collections;
using System.Collections.Generic;

namespace Heroes
{
    public class StartUp
    {
        public static void Main()
        {

            // IHero barbarian = new Barbarian("asd", 10, 20);
            // barbarian.
            // IEngine engine = new Engine();
            // engine.Run();

            IWeapon weapon = new Mace("asd", 20);
            IWeapon weapon2 = new Claymore("asd", 20);
            IWeapon weapon3 = new Mace("asd", 20);
            IHero hero = new Barbarian("Ragnar", 100, 100);
            IHero hero2 = new Barbarian("Lagerta", 100, 100);
            IHero hero3 = new Knight("Lagerta", 100, 100);
            IHero hero4 = new Knight("Lagerta", 100, 100);

            List<IHero> hereos = new List<IHero>();
            hero.AddWeapon(weapon);
            hero2.AddWeapon(weapon);
            hero3.AddWeapon(weapon2);
            hero2.AddWeapon(weapon2);


            hereos.Add(hero);
            hereos.Add(hero2);
            hereos.Add(hero3);
            hereos.Add(hero4);
            IMap map = new Map();
            map.Fight(hereos);
        }
    }
}
