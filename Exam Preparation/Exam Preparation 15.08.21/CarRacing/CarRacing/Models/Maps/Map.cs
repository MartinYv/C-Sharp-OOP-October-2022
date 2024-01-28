using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {

      public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            string winner = "";
            string loser = "";

            if (racerOne.IsAvailable() == false || racerTwo.IsAvailable() == false)
            {


                if (racerOne.IsAvailable() == false)
                {
                    winner = racerTwo.Username;
                    loser = racerOne.Username;
                   
                }
                else
                {
                    winner = racerOne.Username;
                    loser = racerTwo.Username;

                }

                return string.Format(OutputMessages.OneRacerIsNotAvailable, winner, loser);
            }

            double racerOneResult = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            double racerTwoResult = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;

            if (racerOne.RacingBehavior == "strict")
            {
                racerOneResult *= 1.2;
            }
            else
            {
                racerOneResult *= 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                racerTwoResult *= 1.2;
            }
            else
            {
                racerTwoResult *= 1.1;
            }


            if (racerOneResult < racerTwoResult)
            {
                winner = racerTwo.Username;
                loser = racerOne.Username;

            }
            else if (racerOneResult > racerTwoResult)
            {
                winner = racerOne.Username;
                loser = racerTwo.Username;
            }


            racerOne.Race();
            racerTwo.Race();

            racerOne.Car.Drive();
            racerTwo.Car.Drive();

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner);

        }
    }
}
