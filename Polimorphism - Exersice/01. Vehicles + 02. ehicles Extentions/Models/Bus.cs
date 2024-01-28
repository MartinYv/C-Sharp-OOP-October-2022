using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public  class Bus : IVehicle
    {
        private const double IF_BUS_IS_NOT_EMPTY = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            TankCapacity = tankCapacity;
        }
        public double FuelQuantity { get; set ; }
        public double FuelConsumptionPerKm { get; set; }
        public double TankCapacity { get; set; }


        public void Drive(double distance)
        {
           double fuelConsumptionForTheRide= FuelConsumptionPerKm + IF_BUS_IS_NOT_EMPTY;
            

            double fuelLeft = FuelQuantity - distance * fuelConsumptionForTheRide;

            if (fuelLeft >= 0)
            {
                FuelQuantity -= distance * fuelConsumptionForTheRide;
                Console.WriteLine($"{typeof(Bus).Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{typeof(Bus).Name} needs refueling");
            }
        }
        public void Drive(double distance, string isItEmpty)
        {
            double fuelLeft = FuelQuantity - distance * FuelConsumptionPerKm;

            if (fuelLeft >= 0)
            {
                FuelQuantity -= distance * FuelConsumptionPerKm;
                Console.WriteLine($"{typeof(Bus).Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{typeof(Bus).Name} needs refueling");
            }
        }

        public void Refuel(double fuel)
        {
            if (fuel <=0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (fuel + FuelQuantity < TankCapacity)
            {
                FuelQuantity += fuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }
    }
}
