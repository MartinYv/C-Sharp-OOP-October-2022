using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
  public  class Spy
    {
        //"Class under investigation: {nameOfTheClass}"
        //"{filedName} = {fieldValue}"
        public string StealFieldInfo(string nameOfTheClass, params string[] fieldsInfo)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Assembly.GetCallingAssembly().GetType(nameOfTheClass);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
            object instance = Activator.CreateInstance(classType, new object[] {});


            sb.AppendLine($"Class under investigation: {nameOfTheClass}");

            foreach (FieldInfo field in fields.Where(f => fieldsInfo.Contains(f.Name)))
            {
               
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
