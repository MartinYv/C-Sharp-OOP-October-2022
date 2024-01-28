using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Bird : Animal
    {
        public Bird(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten)
        {
            WingSize = wingSize;

        }

        public double WingSize { get; set; }

        public override void ProduceSound()
        {
           
        }

        public override void ToString()
        {
          
        }
    }
}
