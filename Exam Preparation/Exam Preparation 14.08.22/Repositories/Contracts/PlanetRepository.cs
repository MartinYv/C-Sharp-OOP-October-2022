using PlanetWars.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories.Contracts
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => planets.AsReadOnly();

        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return planets.FirstOrDefault(x => x.Name == name);
        
        }

        public bool RemoveItem(string name)
        {
            bool doesExist = planets.Any(x => x.Name == name);

            if (doesExist == true)
            {
                var planet = planets.First(x => x.Name == name);
                planets.Remove(planet);
            }

            return doesExist;
        }
    }
}
