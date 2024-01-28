using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        private const double SPACEMISSILES_PRICE = 8.75;
        public SpaceMissiles(int destructionLevel) : base(destructionLevel, SPACEMISSILES_PRICE)
        {
        }
    }
}
