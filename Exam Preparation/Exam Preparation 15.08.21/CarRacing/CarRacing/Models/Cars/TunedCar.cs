using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double SUPERCAR_AVAILABLEFUEL = 65;
        private const double SUPERCAR_FUELCONSUMPTIONPERRACE = 7.5;



        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, SUPERCAR_AVAILABLEFUEL, SUPERCAR_FUELCONSUMPTIONPERRACE)
        {
        }



    public override void Drive()
    {

        base.Drive();

        HorsePower -= (int)Math.Round(HorsePower * 0.03);
    }
    }
}
