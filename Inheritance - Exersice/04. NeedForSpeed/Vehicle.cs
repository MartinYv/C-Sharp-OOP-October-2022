using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {        // · A constructor that accepts the following parameters: int horsePower, double fuel
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        //· DefaultFuelConsumption – double
        //
        //· FuelConsumption – virtual double
        //
        //· Fuel – double
        //
        //· HorsePower – int
        //
        //· virtual void Drive(double kilometers)
        //
        //o The Drive method should have a functionality to reduce the Fuel based on the traveled kilometers.

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        
        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel -= FuelConsumption * kilometers;
        }
    }

}
