using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        

        private const double PRICE_MULLEDWINE = 13.50;

        public MulledWine(string cocktailName, string size) : base(cocktailName, size, PRICE_MULLEDWINE)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
