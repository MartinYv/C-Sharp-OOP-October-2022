using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {

        const double COFFIE_MILILITERS = 50;
        const decimal COFFIE_PRICE = 3.5m;
        public Coffee(string name, double caffeine) : base(name, COFFIE_PRICE, COFFIE_MILILITERS)
        {
            Caffeine = caffeine;
        }
      
      
        public double Caffeine { get;set;} 
    }
}
