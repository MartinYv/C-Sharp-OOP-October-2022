using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double BIOLOGIST_OXIGEN = 70; 
        public Biologist(string name) : base(name, BIOLOGIST_OXIGEN)
        {

        }


        public override void Breath()
        {
            if (Oxygen - 5 < 0)
            {
                Oxygen = 0;
                CanBreath = false;
            }
            else
            {
                Oxygen -= 5;
            }
        }
    }
}
