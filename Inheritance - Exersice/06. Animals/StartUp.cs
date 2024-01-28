using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();


            string command;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string animal = command;

                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info[2];


                if (animal == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (animal == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (animal == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }
                else if (animal == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age, gender);
                    animals.Add(kitten);
                }
                else if (animal == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age, gender);
                    animals.Add(tomcat);
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }

            }

            animals.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
