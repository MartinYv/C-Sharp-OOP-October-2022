﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
   public class Spy
    {
       public string StealFieldInfo(string nameOfClass , params string [] nameOfFields)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(nameOfClass);
            sb.AppendLine($"Class under investigation: {classType.Name}");

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);

            object createInstance = Activator.CreateInstance(classType, new object[] { });

            foreach (FieldInfo field in fields.Where(f=> nameOfFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(createInstance)}");
            }
            return sb.ToString();
        }

      public string  AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] methodsPublic = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance );
            MethodInfo[] methodsNonPublic = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance );

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");

            }
            foreach (var method in methodsNonPublic.Where(x => x.Name.StartsWith("get")))
            {

                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in methodsPublic.Where(x => x.Name.StartsWith("set")))
            {

                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

       public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            Type baseClass = classType.BaseType;
            sb.AppendLine($"All Private Methods of Class: {classType}");
            sb.AppendLine($"Base Class: {baseClass.Name}");

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
