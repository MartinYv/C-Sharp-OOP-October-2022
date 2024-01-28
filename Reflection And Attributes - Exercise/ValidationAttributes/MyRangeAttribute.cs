using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : IMyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
           this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int currValue = (int)obj;

            if (currValue >= minValue && currValue <= maxValue)
            {
                return true;
            }
            return false;
        }
    }
}
