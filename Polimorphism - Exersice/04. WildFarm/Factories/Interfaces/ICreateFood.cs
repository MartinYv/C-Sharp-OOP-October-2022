using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Interfaces
{
   public interface ICreateFood
    {
         IFood FoodCreate(string type, int quantity);
    }
}
