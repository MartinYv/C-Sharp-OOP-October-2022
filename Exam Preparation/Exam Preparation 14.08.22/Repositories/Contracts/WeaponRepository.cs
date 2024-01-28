using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories.Contracts
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();


        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            var weapon = weapons.FirstOrDefault(x => x.GetType().Name == name);
            return weapon;
        }

        public bool RemoveItem(string name)
        {
            bool doesExist = weapons.Any(x => x.GetType().Name == name);

            if (doesExist == true)
            {
                var weapon = weapons.First(x => x.GetType().Name == name);
                weapons.Remove(weapon);
            }

            return doesExist;
        }
    }
}
