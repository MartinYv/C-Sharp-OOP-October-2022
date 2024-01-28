using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
   public class Geodesist : Astronaut
    {
        private const double GEODESIST_OXIGEN = 50;
        public Geodesist(string name) : base(name, GEODESIST_OXIGEN)
        {
        }

        public override void Breath()
        {
            
            if (Oxygen -10 < 0)
            {
                Oxygen = 0;
                CanBreath = false;
            }
            else
            {
                Oxygen -= 10;
            }
        }
    }
}
