using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
          
            try
            {
                string[] infoPizzaName = Console.ReadLine().Split();

                string pizzaName = infoPizzaName[1];
                Pizza pizza = new Pizza(pizzaName);


                string command;
                while ((command = Console.ReadLine()) != "END")
                {

                    string[] info = command.Split();
                    string action = info[0];


                    if (action == "Topping")
                    {
                        string toppingType = info[1];
                        int grams = int.Parse(info[2]);

                        Topping topping = new Topping(toppingType, grams);
                        pizza.AddTopping(topping);
              
                    }
                    else if (action == "Dough")
                    {
                        string doughType = info[1];
                        string bakingType = info[2];
                        int grams = int.Parse(info[3]);

                        Dough dough = new Dough(doughType, bakingType, grams);
                        pizza.Dough = dough;
                      
                    }

                }

                Console.WriteLine($"{pizza.GetPizzaName} - {pizza.GetTotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
