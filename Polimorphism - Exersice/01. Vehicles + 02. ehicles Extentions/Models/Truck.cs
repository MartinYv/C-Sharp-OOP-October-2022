using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Polimorphism
{
    public class Truck : IVehicle
    {
        private const double TRUCK_INCRASED_FUEL_CONSUMPTION = 1.6;
        private const double TRUCK_REFUEL_MULTIPLIER = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumption + TRUCK_INCRASED_FUEL_CONSUMPTION;
            TankCapacity = tankCapacity;

        }
        public double FuelQuantity { get ; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TankCapacity { get; set; }
        public void Drive(double distance)
        {
            double fuelLeft = FuelQuantity - distance * FuelConsumptionPerKm;
            if (fuelLeft >= 0)
            {
                FuelQuantity -= distance * FuelConsumptionPerKm;
                Console.WriteLine($"{typeof(Truck).Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{typeof(Truck).Name} needs refueling");
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
                FuelQuantity += fuel * TRUCK_REFUEL_MULTIPLIER;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            
        }

    }
}
