using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        
        private string flourType;
        private string bakingTechnique;
        private Dictionary<string, double> modifiers;
        private double grams;


        public Dough(string flourType, string bakingTechnique, double grams)
        {
            modifiers = new Dictionary<string, double>();
            modifiers.Add("white", 1.5);
            modifiers.Add("wholegrain", 1.0);
            modifiers.Add("crispy", 0.9);
            modifiers.Add("chewy", 1.1);
            modifiers.Add("homemade", 1.0);

            
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }
       

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                string type = $"{char.ToUpper(value[0])}{value.Substring(1)}";

                string comparison = value.ToLower();

                if (!modifiers.ContainsKey(comparison))
                {
                    throw new ArgumentException($"Cannot place {type} on top of your pizza.");
                }
               value = comparison;
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                string type = $"{char.ToUpper(value[0])}{value.Substring(1)}";

                string comparison = value.ToLower();

                if (!modifiers.ContainsKey(comparison))
                {
                    throw new ArgumentException($"Cannot place {type} on top of your pizza.");
                }
               value = comparison;
                bakingTechnique = value;
            }
        }

        public IReadOnlyDictionary<string, double> Modifiers
        {
            get { return modifiers; }
            //private set { modifiers = value; }
        }

        public  double Grams
        {
            get { return grams; }
            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }


        private double Calories(Dough dough)
        {
            double callories = (2 * dough.Grams) * modifiers[dough.FlourType] * modifiers[dough.BakingTechnique];
            return callories;
            //return $"{callories:f2}";
    }

        public double GetterDoughCalories(Dough dough) => Calories(dough);
    }
}