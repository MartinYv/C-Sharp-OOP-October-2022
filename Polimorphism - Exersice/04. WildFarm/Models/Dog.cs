using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

        public override void ToString()
        {
            Console.WriteLine($"{typeof(Dog).Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]");
        }
    }
}
