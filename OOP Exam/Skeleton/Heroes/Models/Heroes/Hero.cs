using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        private bool isAlive= true;
        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
            

        }
        public string Name
        {
            get { return name; }
            set
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
            get { return health; }
            set
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
            get { return armour; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                armour = value; }
        }

    public IWeapon Weapon
        {
            get { return weapon; }
            set
            {
                if (weapon == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

               weapon=value ;
            }
        }
    public bool IsAlive
        {
            get { return isAlive; }
            set
            {

                if (health>0)
                {
                    isAlive= true;
                }
                else
                {
                    isAlive = false;
                }

                isAlive = value;
            }
        }

    public void AddWeapon(IWeapon weapon)
    {
            this.weapon = weapon;
    }

    public void TakeDamage(int points)
    {
            if (Armour > 0)
            {
                Armour -= points;
                if (Armour < 0)
                {
                    int difference = Math.Abs(Armour);
                    Armour = 0;

                    Health -= difference;
                }
            }

            else
            {
                Health -= points;
            }

            if (Health <= 0)
            {
                Health = 0;

                IsAlive = false;
            }
    }
}
}
