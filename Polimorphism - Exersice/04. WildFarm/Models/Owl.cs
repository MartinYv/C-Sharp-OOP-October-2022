using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
        public override void ToString()
        {
            Console.WriteLine($"{typeof(Owl).Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]");
        }
    }

}
