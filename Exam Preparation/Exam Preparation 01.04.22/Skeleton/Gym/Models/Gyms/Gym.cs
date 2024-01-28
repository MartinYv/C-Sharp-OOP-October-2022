using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Athletes = new List<IAthlete>();
            Equipment = new List<IEquipment>();
        }


        public string Name
        {
            get
            {
                return name;
            }
           private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => Equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity <= Athletes.Count)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughSize);
            }

            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var currAthlete in Athletes)
            {
                currAthlete.Exercise();
            }
        }

        public string GymInfo()
        {
            //"{gymName} is a {gymType}:"
            // Athletes: { athleteName1}, { athleteName2}, { athleteName3} (…) / No athletes         
            //Equipment total count: {equipmentCount}
            //Equipment total weight: {equipmentWeight} grams"

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {this.GetType().Name}:");

            string result = Athletes.Count > 0 ? $"Athletes {string.Join(" ", Athletes.Select(x=>x.FullName))}" : "No athletes";
            sb.AppendLine(result);
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            bool isExistingAthlete = Athletes.Contains(athlete);

            if (isExistingAthlete == true)
            {
                Athletes.Remove(athlete);
            }

            return isExistingAthlete;
        }
    }
}
