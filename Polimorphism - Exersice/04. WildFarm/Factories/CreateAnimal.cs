using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class CreateAnimal : ICreateAnimal
    {

        public IAnimal CreateBird(string type, string name, double weight, int foodEaten, double wingsize)
        {
            IAnimal animal = null;

            if (type == "Owl")
            {
                animal = new Owl(name, weight, foodEaten, wingsize);
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, foodEaten, wingsize);
            }

            return animal;
        }

        public IAnimal CreateMammal(string type, string name, double weight, int foodEaten, string livingRegion)
        {

            IAnimal animal = null;

            if (type == "Mouse")
            {
                animal = new Mouse(name, weight, foodEaten,livingRegion);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, foodEaten, livingRegion);
            }
           

            return animal;
        }

        public IAnimal CreateFeline(string type, string name, double weight, int foodEaten, string livingRegion, string breed)
        {
            IAnimal animal = null;

             if (type == "Cat")
            {

                animal = new Cat(name, weight, foodEaten, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, foodEaten, livingRegion, breed);
            }

            return animal;
        }

       
    }
}
