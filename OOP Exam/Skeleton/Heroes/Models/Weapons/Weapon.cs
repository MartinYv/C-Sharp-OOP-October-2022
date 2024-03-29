﻿using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon :IWeaponDmg, IWeapon
    {
        private string name;
        private int durability;

        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }
        public string Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }

                name = value;
            }
        }

        

        public int Durability
        {
            get { return durability; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }

                durability = value; 
            }
        }

        public int Damage { get; set ; }

        public abstract int DoDamage();
       
    }
}
