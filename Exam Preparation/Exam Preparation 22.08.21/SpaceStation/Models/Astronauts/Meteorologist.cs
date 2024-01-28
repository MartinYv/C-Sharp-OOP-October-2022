using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double METEOROLOGIST_OXIGEN = 90;
        public Meteorologist(string name) : base(name, METEOROLOGIST_OXIGEN)
        {
        }

        public override void Breath()
        {
            if (Oxygen - 10 < 0)
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
