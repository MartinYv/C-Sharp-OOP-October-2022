using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories.Contracts
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;

        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }



        public IReadOnlyCollection<IMilitaryUnit> Models => units.AsReadOnly();

        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            var unit = units.FirstOrDefault(x => x.GetType().Name == name);
            return unit;
        }

        public bool RemoveItem(string name)
        {
            bool doesExist = units.Any(x => x.GetType().Name == name);

            if (doesExist == true)
            {
                var unit = units.First(x => x.GetType().Name == name);
                units.Remove(unit);
            }

            return doesExist;
        }
    }
}
