using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int HAPPYBUNNY_ENERGY = 100;
        public HappyBunny(string name) : base(name, HAPPYBUNNY_ENERGY)
        {
        }

        public override void Work()
        {
            Energy -= 10;
        }
    }
}