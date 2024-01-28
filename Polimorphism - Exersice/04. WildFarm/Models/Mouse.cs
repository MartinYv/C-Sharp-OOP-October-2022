using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    internal class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
        public override void ToString()
        {
            Console.WriteLine($"{typeof(Mouse).Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]");
        }
    }
}
