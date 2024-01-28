using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;
using WildFarm.Models;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly List<IAnimal> animals;
        private readonly ICreateAnimal createAnimal;
        private readonly ICreateFood foodCreate;

        public Engine()
        {
            animals = new List<IAnimal>();
            createAnimal = new CreateAnimal();

            foodCreate = new CreateFood();
        }
        public void Run()
        {

            string input;
            while ((input = Console.ReadLine()) != "End")
            {

                IAnimal animal;
                IFood food;

                string[] animalInfo = input.Split();
                string[] foodInfo = Console.ReadLine().Split();

                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);

                string typeOfTheAnimal = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                food = foodCreate.FoodCreate(foodType, foodQuantity);


                if (typeOfTheAnimal == "Cat")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];

                    if (foodType != "Vegetable" && foodType != "Meat")
                    {
                        animal = createAnimal.CreateFeline(typeOfTheAnimal, name, weight, 0, livingRegion, breed);
                        animal.ProduceSound();

                        Console.WriteLine($"{typeOfTheAnimal} does not eat {foodType}!");
                    }
                    else
                    {
                        animal = createAnimal.CreateFeline(typeOfTheAnimal, name, weight += food.Quantity * 0.3, food.Quantity, livingRegion, breed);
                        animal.ProduceSound();

                    }
                    animals.Add(animal);
                }
                else if (typeOfTheAnimal == "Dog")
                {
                    string livingRegion = animalInfo[3];


                    if (foodType != "Meat")
                    {
                        animal = createAnimal.CreateMammal(typeOfTheAnimal, name, weight, 0, livingRegion);
                        animal.ProduceSound();

                        Console.WriteLine($"{typeOfTheAnimal} does not eat {foodType}!");
                    }
                    else
                    {
                        animal = createAnimal.CreateMammal(typeOfTheAnimal, name, weight += food.Quantity * 0.4, food.Quantity, livingRegion);
                        animal.ProduceSound();

                    }
                    animals.Add(animal);
                }
                else if (typeOfTheAnimal == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];

                    if (foodType != "Meat")
                    {
                        animal = createAnimal.CreateFeline(typeOfTheAnimal, name, weight, 0, livingRegion, breed);
                        animal.ProduceSound();

                        Console.WriteLine($"{typeOfTheAnimal} does not eat {foodType}!");
                    }
                    else
                    {
                        animal = createAnimal.CreateFeline(typeOfTheAnimal, name, weight += food.Quantity * 1, food.Quantity, livingRegion, breed);
                        animal.ProduceSound();

                    }
                    animals.Add(animal);
                }

                else if (typeOfTheAnimal == "Mouse")
                {
                    string livingRegion = animalInfo[3];

                    if (foodType != "Vegetable" && foodType != "Fruit")
                    {
                        animal = createAnimal.CreateMammal(typeOfTheAnimal, name, weight, 0, livingRegion);
                        animal.ProduceSound();
                        Console.WriteLine($"{typeOfTheAnimal} does not eat {foodType}!");

                    }
                    else
                    {
                        animal = createAnimal.CreateMammal(typeOfTheAnimal, name, weight += food.Quantity * 0.1, food.Quantity, livingRegion);
                        animal.ProduceSound();

                    }
                    animals.Add(animal);
                }

                else if (typeOfTheAnimal == "Owl")
                {
                    
                    double wingSize = double.Parse(animalInfo[3]);
                    if (foodType != "Meat")
                    {

                        animal = createAnimal.CreateBird(typeOfTheAnimal, name, weight, 0, wingSize);
                        animal.ProduceSound();

                        Console.WriteLine($"{typeOfTheAnimal} does not eat {foodType}!");
                    }
                    else
                    {
                        animal = createAnimal.CreateBird(typeOfTheAnimal, name, weight += food.Quantity * 0.25, food.Quantity, wingSize);
                        animal.ProduceSound();

                    }
                    animals.Add(animal);
                }

                else if (typeOfTheAnimal == "Hen")
                {
                   
                    double wingSize = double.Parse(animalInfo[3]);

                    animal = createAnimal.CreateBird(typeOfTheAnimal, name, weight += food.Quantity * 0.35, food.Quantity, wingSize);

                    animals.Add(animal);
                    animal.ProduceSound();

                }
            }

            foreach (var item in animals)
            {
                item.ToString();
            }
        }
    }
}