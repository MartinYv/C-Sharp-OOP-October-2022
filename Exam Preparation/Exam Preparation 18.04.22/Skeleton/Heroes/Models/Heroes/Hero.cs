using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        private bool isAlive;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
            isAlive = true;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");

                }

                health = value;
            }
        }
        public int Armour
        {
            get
            {
                return armour;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");

                }

                armour = value;
            }
        }
        public IWeapon Weapon
        {
            get
            {
                return weapon;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");

                }

                weapon = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            protected set
            {


                if (Health <= 0)
                {
                    value = false;
                }

                isAlive = value;
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            if (Armour - points >= 0)
            {
                Armour -= points;
            }
            else if (Armour - points < 0)
            {

                if (Health - points > 0)
                {
                    Health -= Math.Abs(Armour-points);
                Armour = 0;
                }
                else
                {

                    IsAlive = false;
                    Health = 0;
                    Armour = 0;

                }
            }
        }
    }
}
