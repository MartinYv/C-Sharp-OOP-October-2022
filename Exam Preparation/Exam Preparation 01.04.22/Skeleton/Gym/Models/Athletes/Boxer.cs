using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int BOXER_STAMINA = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, BOXER_STAMINA)
        {
        }

        public override void Exercise()
        {
            Stamina += 15;
        }
    }
}
