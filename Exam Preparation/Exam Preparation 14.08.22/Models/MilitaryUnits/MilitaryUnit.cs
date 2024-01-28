﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }


        public double Cost { get; private set; }

        public int EnduranceLevel
        {
            get
            {
                return enduranceLevel;
            }
            private set
            {
                if (value > 20)
                {
                    value = 20;
                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }


                enduranceLevel = value;
            }
        }
        public void IncreaseEndurance()
        {
            EnduranceLevel += 1;
        }
    }
}
