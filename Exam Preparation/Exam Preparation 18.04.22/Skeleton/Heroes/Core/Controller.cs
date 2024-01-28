using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {

        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {

            if (heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero { heroName} does not exist.");
            }

            if (weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            IHero hero = heroes.FindByName(heroName);
            IWeapon weapon = weapons.FindByName(weaponName);

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            string weaponType = weapon.GetType().Name.ToLower();

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weaponType}.";

        }

        public string CreateHero(string type, string name, int health, int armour)
        {


            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException("The hero { name } already exists.");
            }

            if (type != "Barbarian" && type != "Knight")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            IHero hero = null;
            if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Barbarian { name } to the collection.";
            }
            else
            {
                hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Sir { name } to the collection.";
            }

        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException("The weapon { name } already exists.");
            }

            if (type != "Claymore" && type != "Mace")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            IWeapon weapon = null;
            if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }
            else
            {
                weapon = new Mace(name, durability);
            }

            weapons.Add(weapon);

            return $"A {type.ToLower()} { name } is added to the collection.";
        }

        public string HeroReport()
        {
            var sortedHeroes = heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var hero in sortedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health }");
                sb.AppendLine($"--Armour: {hero.Armour}");

                string result = hero.Weapon != null ? $"{hero.Weapon.Name}" : $"Unarmed";

                sb.AppendLine($"--Weapon: {result}");
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();

            var sortedHeroes = heroes.Models.Where(x => x.IsAlive == true && x.Weapon != null).ToList();

            return map.Fight(sortedHeroes);
        }
    }
}