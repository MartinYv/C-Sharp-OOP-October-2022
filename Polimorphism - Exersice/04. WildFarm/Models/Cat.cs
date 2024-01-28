using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }

        public override void ToString()
        {
            Console.WriteLine($"{typeof(Cat).Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]");
        }
    }
}
