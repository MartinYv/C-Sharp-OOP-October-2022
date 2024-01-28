using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void ToString()
        {
            Console.WriteLine($"{typeof(Tiger).Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]");
        }
    }
}
