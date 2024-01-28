using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Interfaces
{
  public interface IAnimal
    {
       
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public void ProduceSound();
        public void ToString();
    }
}
