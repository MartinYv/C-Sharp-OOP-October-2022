using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int CLAYMORE_DMG = 20;
        public Claymore(string name, int durability) : base(name, durability)
        {
            Damage = CLAYMORE_DMG;
        }


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
