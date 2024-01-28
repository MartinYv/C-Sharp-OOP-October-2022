using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
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
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }
        public string Size { get; } //Possible values: "Small", "Middle", "Large". this.Size will be validated later in the Controller class.

        public double Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (Size == "Large")
                {
                   
                }
                else if (Size == "Middle")
                {
                    value /= 1.5;   
                }
                else if (Size == "Small")
                {
                    value /=  3;
                }

                price = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
