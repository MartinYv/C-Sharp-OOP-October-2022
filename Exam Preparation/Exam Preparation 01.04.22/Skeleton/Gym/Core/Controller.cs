using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;

        private List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
           
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new Exception(ExceptionMessages.InvalidAthleteType);
            }

            var currGym = gyms.Find(x => x.Name == gymName);
            string gymType = currGym.GetType().Name;

            IAthlete athlete = null;

            if (athleteType == "Boxer" && gymType == "BoxingGym")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                currGym.AddAthlete(athlete);
            }
            else if (athleteType == "Weightlifter" && gymType == "WeightliftingGym")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                currGym.AddAthlete(athlete);
            }
            else
            {
                throw new InvalidOperationException(OutputMessages.InappropriateGym);
            }

            throw new Exception(string.Format(OutputMessages.EntityAddedToGym,athleteType, gymName));
        }

        public string AddEquipment(string equipmentType)
        {
            //"BoxingGloves" and "Kettlebell".
            IEquipment currEquipment = null;

            if (equipmentType == "BoxingGloves")
            {
                currEquipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                currEquipment = new Kettlebell();
            }
            else
            {
                //throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipment.Add(currEquipment);

            throw new Exception(string.Format(OutputMessages.SuccessfullyAdded, currEquipment.GetType().Name));

        }

        public string AddGym(string gymType, string gymName)
        {
            //" BoxingGym" and " WeightliftingGym".

            IGym gym = null;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gyms.Add(gym);
            throw new Exception(string.Format(OutputMessages.SuccessfullyAdded, gym.GetType().Name)); //to do the message

        }

        public string EquipmentWeight(string gymName)
        {
            var currGym = gyms.Find(x => x.Name == gymName);
            double weight = currGym.EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {weight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var currGym = gyms.Find(x => x.Name == gymName);

            var currEquipment = equipment.FindByType(equipmentType);

            if (currEquipment == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            currGym.Equipment.Add(currEquipment);
            equipment.Remove(currEquipment);

            throw new Exception(string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName));


        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();

        }

        public string TrainAthletes(string gymName)
        {
            //"Exercise athletes: {athletesCount}."
            var currGym = gyms.Find(x => x.Name == gymName);

            foreach (var athlete in currGym.Athletes)
            {

                athlete.Exercise();

            }

            return $"Exercise athletes: {currGym.Athletes.Count}.";
        }
    }
}