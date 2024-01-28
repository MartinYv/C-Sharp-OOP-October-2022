using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
  public interface ICreateAnimal
    {

        public IAnimal CreateBird(string type, string name, double weight, int foodEaten, double wingsize);

        public IAnimal CreateMammal(string type, string name, double weight, int foodEaten, string livingRegion);

        public IAnimal CreateFeline(string type, string name, double weight, int foodEaten,string livingRegion, string breed);
    }
}
