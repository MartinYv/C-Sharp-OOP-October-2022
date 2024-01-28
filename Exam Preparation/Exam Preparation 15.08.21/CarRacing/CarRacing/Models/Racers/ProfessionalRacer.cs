using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int PROFFESIONALRACER_DRIVINGEXP = 30;
        private const string PROFFESIONALRACER_DRIVINGBEHAVOUR = "strict";
        public ProfessionalRacer(string username, ICar car) : base(username, PROFFESIONALRACER_DRIVINGBEHAVOUR, PROFFESIONALRACER_DRIVINGEXP, car)
        {
        }
    }
}
