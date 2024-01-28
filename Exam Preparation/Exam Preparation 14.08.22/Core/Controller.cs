using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {

        private IRepository<IPlanet> planetsRepository;
        private IRepository<IWeapon> weaponsRepository;
        private IRepository<IMilitaryUnit> unitsRepository;
        public Controller()
        {
            planetsRepository = new PlanetRepository();
            weaponsRepository = new WeaponRepository();
            unitsRepository = new UnitRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planetsRepository.FindByName(planetName);

            if (planetsRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var IsValidUnitType = unitsRepository.FindByName(unitTypeName);

            if (IsValidUnitType == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));

            }

            string unitType = unitsRepository.FindByName(unitTypeName).ToString();

            if (unitType != "AnonymousImpactUnit" &&
                unitType != "MilitaryUnit" &&
                 unitType != "SpaceForces" &&
                 unitType != "StormTroopers")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }


            if (unitsRepository.FindByName(unitTypeName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));

            }


            



            var assembly = Assembly.GetCallingAssembly();
            var type = Assembly.GetCallingAssembly().GetTypes().Where(x => x.Name == unitTypeName);
           var instance =  Activator.CreateInstance(assembly.FullName, type.GetType().Name) as IMilitaryUnit;

            planet.AddUnit(instance);
            throw new Exception(String.Format(OutputMessages.UnitAdded, unitTypeName, planetName));

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planetsRepository.FindByName(planetName);
         

            if (planetsRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(x=>x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded,weaponTypeName, planetName));

            }


            string weaponType = weaponsRepository.FindByName(weaponTypeName).ToString();

            if (weaponType != "BioChemicalWeapon" &&
                weaponType != "NuclearWeapon" &&
                 weaponType != "SpaceMissiles")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == weaponTypeName);
            var instance = Activator.CreateInstance(type) as IWeapon;


            planet.AddWeapon(instance);
            throw new Exception(String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName ));

        }

        public string CreatePlanet(string name, double budget)
        {
            
            
            if (planetsRepository.FindByName(name) == null)
            {
                IPlanet planet = new Planet(name, budget);
                planetsRepository.AddItem(planet);
                throw new Exception(string.Format(OutputMessages.NewPlanet, name));
            }
            else
            {
                throw new Exception(string.Format(OutputMessages.ExistingPlanet, name));
            }
        }

        public string ForcesReport()
        {
            //var orderedPlanets = planets.Select(x => x.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name)).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var currPlanet in planetsRepository.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                
                    sb.AppendLine(currPlanet.PlanetInfo());               
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            
            var firstPlanet = planetsRepository.FindByName(planetOne);
            var secondPlanet = planetsRepository.FindByName(planetTwo);


                bool firstHasNuclear = firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
                bool secondHasNuclear = secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");



            IPlanet winner = null;
            IPlanet loser = null;


            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                winner = firstPlanet;
                loser = secondPlanet;
            }
            else if (firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
            {
                winner = secondPlanet;
                loser = firstPlanet;
            }

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {

                if (firstHasNuclear == true && secondHasNuclear == true || firstHasNuclear == false && secondHasNuclear == false)
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    throw new Exception(OutputMessages.NoWinner);
                }


                
                if (firstHasNuclear == true && secondHasNuclear == false)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else if (firstHasNuclear == false && secondHasNuclear == true)
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }

            }


                winner.Spend(winner.Budget / 2);
                winner.Profit(loser.Budget / 2);
                winner.Profit(loser.Weapons.Select(x => x.Price).Sum());
                winner.Profit(loser.Army.Select(x => x.Cost).Sum());

                planetsRepository.RemoveItem(loser.Name);
                throw new Exception(string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name));

        }

        public string SpecializeForces(string planetName)
        {
            var planet = planetsRepository.FindByName(planetName);
            

            if (planetsRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException((ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(1.25);
            planet.TrainArmy();
            throw new Exception(String.Format(OutputMessages.ForcesUpgraded, planetName));

        }
    }
}
