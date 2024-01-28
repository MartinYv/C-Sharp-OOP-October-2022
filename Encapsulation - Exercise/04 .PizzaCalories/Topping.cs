using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
       
        private string toppingType;
        private double gramsOfTopping;
        private Dictionary<string,double> modifiers;

   
        public Topping(string topping, double grams)
        {
            modifiers = new Dictionary<string, double>();
            
            modifiers.Add("meat", 1.2);
            modifiers.Add("veggies", 0.8);
            modifiers.Add("cheese", 1.1);
            modifiers.Add("sauce", 0.9);


            
            ToppingType = topping;
            GramsOfTopping = grams;
        }

      
        public string ToppingType
        {
            get { return toppingType; }
         private   set
            {
                string type= $"{char.ToUpper(value[0])}{value.Substring(1)}";

                string comparison = value.ToLower(); 
                
                if (!modifiers.ContainsKey(comparison))
                {
                    throw new ArgumentException($"Cannot place {type} on top of your pizza.");
                }
               value= comparison;
                toppingType = value;
            }
        }
        public double GramsOfTopping
        {
            get { return gramsOfTopping; }
          private  set 
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }

                gramsOfTopping = value; 
            }
        }

        private double Calories(Topping topping)
        {
            double callories = (2 * topping.gramsOfTopping) * modifiers[topping.toppingType];
            return callories;
            //return $"{callories:f2}";
        }

        public double GetterToppingCalories (Topping topping) => Calories(topping);
    }
}