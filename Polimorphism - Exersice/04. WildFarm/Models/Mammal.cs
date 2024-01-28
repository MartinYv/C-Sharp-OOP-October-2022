using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models
{
    public abstract class Mammal :Animal, IMammal
    {
        

        protected Mammal(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get ; set; }

        public override void ProduceSound()
        {
            
        }

        public override void ToString()
        {
            
        }

    }
}
