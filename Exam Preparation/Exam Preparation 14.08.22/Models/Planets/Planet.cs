using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private List<IRepository<IMilitaryUnit>> army;
        private List<IRepository<IWeapon>> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;

            army = new List<IRepository<IMilitaryUnit>>();
            weapons = new List<IRepository<IWeapon>>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get
            {
                return budget;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower  => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => (IReadOnlyCollection<IMilitaryUnit>)army;

        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)weapons;

        public void AddUnit(IMilitaryUnit unit)
        {
            if (!army.Any(x => x.GetType().Name == unit.GetType().Name))
            {
                army.Add((IRepository<IMilitaryUnit>)unit);
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (!weapons.Any(x => x.GetType().Name == weapon.GetType().Name))
            {
                weapons.Add((IRepository<IWeapon>)weapon);
            }
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine();
            sb.AppendLine($"--Budget: {Budget} billion QUID");

            string resultArmy = army.Count < 0 ? "No units" : $"--Forces: {string.Join(" ", army.Select(x => x.Models.GetType().Name))}";
            sb.AppendLine(resultArmy);

            string resultWeapons = weapons.Count < 0 ? "No weapons" : $"--Combat equipment: {string.Join(" ", weapons.Select(x => x.Models.GetType().Name))}";
            sb.AppendLine(resultWeapons);

            sb.AppendLine(MilitaryPower.ToString());

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
           
            if (Budget - amount < 0)         
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

        }

        public void TrainArmy()
        {

            foreach (var item in army)
            {
                foreach (var typeOfArmy in item.Models)
                {
                    typeOfArmy.IncreaseEndurance();
                }

            }
        }

        private double CalculateMilitaryPower()
        {
            double enduranceSum = 0;

            foreach (var item in army)
            {
                foreach (var squad in item.Models)
                {
                    enduranceSum += squad.EnduranceLevel;
                }
            }

            double weaponDestructionSum = 0;

            foreach (var item in weapons)
            {
                foreach (var x in item.Models)
                {
                    weaponDestructionSum += x.DestructionLevel;
                }
            }

            double totalSum = enduranceSum + weaponDestructionSum;

            if (army.Select(x=>x.Models).Any(x=>x.GetType().Name == "AnonymousImpactUnit"))
            {
                totalSum *= 0.30;         
                    
            }

            if (weapons.Select(x=>x.Models).Any(x=>x.GetType().Name == "NuclearWeapon"))
            {
                totalSum *= 0.45;
            }

            return Math.Round(totalSum, 3);
        }
    }
}
