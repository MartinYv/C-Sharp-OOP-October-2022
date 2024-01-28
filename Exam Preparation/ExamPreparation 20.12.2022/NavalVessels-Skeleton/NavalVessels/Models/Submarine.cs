using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double SUBMARINE_DEFAULTARMOR = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, SUBMARINE_DEFAULTARMOR)
        {
        }

        public bool SubmergeMode { get; private set;}

        public override void RepairVessel()
        {
            if (ArmorThickness < 200)
            {

            ArmorThickness = SUBMARINE_DEFAULTARMOR;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }
            public override string ToString()
        {
            string result = SubmergeMode == false ? "OFF" : "ON";
            return base.ToString() + $" *Submerge mode: {result}";
        }
    }
    }
