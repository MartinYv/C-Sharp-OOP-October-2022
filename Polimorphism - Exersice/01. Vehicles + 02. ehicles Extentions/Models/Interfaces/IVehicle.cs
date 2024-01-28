using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Interfaces
{
   public  interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TankCapacity { get; set; }

        public virtual void Drive(double distance)
        {

        }
        public virtual void Drive(double distance,string typeOfBus)
        {

        }
        public void Refuel(double fuel);
    }
}
