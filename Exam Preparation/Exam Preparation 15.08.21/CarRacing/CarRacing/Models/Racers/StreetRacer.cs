using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int STREETRACER_DRIVINGEXP = 10;
        private const string STREETRACER_DRIVINGBEHAVOUR = "aggressive";
        public StreetRacer(string username, ICar car) : base(username, STREETRACER_DRIVINGBEHAVOUR, STREETRACER_DRIVINGEXP, car)
        {
        }

        public override void Race()
        {
            DrivingExperience += 5;
        }
    }
    
}
