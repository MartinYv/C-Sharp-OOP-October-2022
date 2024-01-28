using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int MACE_DMG = 25;
        public Mace(string name, int durability) : base(name, durability)
        {
            Damage = MACE_DMG;
        }


        public new int Damage { get; set; }
        public override int DoDamage()
        {
            Durability -= 1;
            if (Durability <= 0)
            {
                return 0;
            }
            else
            {
                return Damage;
            }
        }
    }
}
