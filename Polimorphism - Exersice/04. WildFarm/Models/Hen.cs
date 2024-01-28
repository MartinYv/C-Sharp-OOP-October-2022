using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");      
        }
        public override void ToString()
        {
            Console.WriteLine($"{typeof(Hen).Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]");     
        }
    }
}
