using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Interfaces
{
    public class CreateFood : ICreateFood
    {
        IFood ICreateFood.FoodCreate(string type, int quantity)
        {
            IFood food;

            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                food = null;
            }

            return food;
        }

       
    }
}
