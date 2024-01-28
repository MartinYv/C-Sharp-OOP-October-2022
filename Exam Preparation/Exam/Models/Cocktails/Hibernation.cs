using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        private const double Large_Hibernation_Price = 10.50 ;

        public Hibernation(string cocktailName, string size) : base(cocktailName, size, Large_Hibernation_Price)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
