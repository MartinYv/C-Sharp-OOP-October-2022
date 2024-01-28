using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Polimorphism
{
    public class Car : IVehicle
    {
        private const double CAR_INCRASED_FUEL_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm + CAR_INCRASED_FUEL_CONSUMPTION;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumptionPerKm { get; set ; }
        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            double fuelLeft = FuelQuantity - distance * FuelConsumptionPerKm;
            if (fuelLeft >= 0)
            {
                FuelQuantity -= distance * FuelConsumptionPerKm;
                Console.WriteLine($"{typeof(Car).Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{typeof(Car).Name} needs refueling");
            }
            
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
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
