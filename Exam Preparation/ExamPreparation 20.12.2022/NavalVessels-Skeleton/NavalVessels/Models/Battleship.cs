using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Battleship : Vessel, IBattleship
    {
        private const double DEFAULT_ARMORPOINTS = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, DEFAULT_ARMORPOINTS)
        {

        }

        public bool SonarMode { get; private set; }
        public override void RepairVessel()
        {
            ArmorThickness = DEFAULT_ARMORPOINTS;
        }

        public void ToggleSonarMode()
        {
            if (SonarMode == false)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }

        }

        public override string ToString()
        {
            string result = SonarMode == false ? "OFF" : "ON";
            return base.ToString() + $" *Sonar mode: {result}";
        }
    }
}
