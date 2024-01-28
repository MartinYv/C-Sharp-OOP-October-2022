using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int SLEEPYBUNNY_ENERGY = 50;
        public SleepyBunny(string name) : base(name, SLEEPYBUNNY_ENERGY)
        {
        }

        public override void Work()
        {
            Energy -= 15;
        }
    }
}
