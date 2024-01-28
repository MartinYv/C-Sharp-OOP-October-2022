using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
   public abstract class Racer : IRacer
    {
        private string userName;
        private string racingBehavour;
        private int drivingExpirience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username
        {
            get
            {
                return userName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }

                userName = value;
            }
        }
        public string RacingBehavior
        {
            get
            {
                return racingBehavour;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }

                racingBehavour = value;
            }
        }
        public int DrivingExperience
        {
            get
            {
                return drivingExpirience;
            }
            protected set
            {
                if (value < 0 && value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                drivingExpirience = value;
            }
        }
        public ICar Car
        {
            get
            {
                return car;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);

                }
                car = value;
            }
        }
        public bool IsAvailable() => car.FuelAvailable >= car.FuelConsumptionPerRace;


        public virtual void Race()
        { 
            DrivingExperience += 10;
        }
      
    }
}
