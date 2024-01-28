using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
   public class MyRequiredAttribute : IMyValidationAttribute
    {
        public override bool IsValid(object obj) => obj != null;
        
    }
}
