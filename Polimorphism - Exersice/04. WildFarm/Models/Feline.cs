using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Feline : Mammal
    {
        public Feline(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; set; }

        public override void ProduceSound()
        {
            
        }

        public override void ToString()
        {
           
        }
    }
}
