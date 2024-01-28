using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private int explorePlanetsCount;


        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }


        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astonaut = null;

            if (type == "Biologist")
            {
                astonaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astonaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astonaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astonaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {

                planet.Items.Add(item);
            }

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);

        }

        public string ExplorePlanet(string planetName)
        {
            
            var astronautsForMission = astronauts.Models.Where(x => x.Oxygen > 60).ToList();

            if (astronautsForMission.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautCount));
            }
            else
            {
                IMission mission = new Mission();
                IPlanet planet = planets.FindByName(planetName);
                int astroCount = astronautsForMission.Count;

                mission.Explore(planet, astronautsForMission);
                explorePlanetsCount++;

                int deathAstronauts = astroCount - astronautsForMission.Where(x => x.CanBreath == true).Count();

                return string.Format(OutputMessages.PlanetExplored, planetName, deathAstronauts);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{explorePlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astro in astronauts.Models)
            {
               
                sb.AppendLine($"Name: {astro.Name}");
                sb.AppendLine($"Oxygen: {astro.Oxygen}");

                string result = astro.Bag.Items.Count > 0 ? $"{string.Join(", ", astro.Bag.Items)}" : "none";
                sb.AppendLine($"Bag items: {result}");

            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            else
            {
                astronauts.Remove(astronaut);
                return string.Format(OutputMessages.AstronautRetired, astronautName);
            }
        }
    }
}
