using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class WeaponDmg : IWeaponDmg
    {
        public int Damage { get; set; }
    }
}
