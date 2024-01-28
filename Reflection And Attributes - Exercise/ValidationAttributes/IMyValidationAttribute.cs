using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    [AttributeUsage ( AttributeTargets.Property)]
    public abstract class IMyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
        

        
    }
}
