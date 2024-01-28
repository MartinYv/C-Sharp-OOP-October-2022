using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties().Where(x => x.GetCustomAttributes(typeof(IMyValidationAttribute)).Any()).ToArray();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(obj);
                var attribute = prop.GetCustomAttribute<IMyValidationAttribute>();

                bool isValid = attribute.IsValid(value);

                if (!isValid)
                {
                    return true;
                }
            }
                    return false;
                }
                
            }
        }
