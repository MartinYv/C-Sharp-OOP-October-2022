﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {

        private const int CLAYMORE_DMG = 20;
        public Claymore(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (Durability == 0)
            {
                return 0;
            }

            Durability -= 1;

            return CLAYMORE_DMG;
        }
    }
}
