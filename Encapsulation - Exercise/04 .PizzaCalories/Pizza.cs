using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        private Dough dough;
        private List<Topping> toppingList;

        public Pizza(string name)
        {
            toppingList = new List<Topping>();

            Name = name;
           
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; }
        }


        public Dough Dough
        {
            get { return dough; }
             set { dough = value; }
        }


        public List<Topping> ToppingList
        {
            get { return toppingList; }
           private set
            {
               

                toppingList = value; }
        }

        public void AddTopping(Topping topping)
        {
            if (toppingList.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppingList.Add(topping);
        }

        public string GetPizzaName => Name;
        public int GetNumberOfTopping => toppingList.Count;

        public double GetTotalCalories 
        {
            get 
            {
                double total = 0;

                for (int i = 0; i < toppingList.Count; i++)
                {
                    total += toppingList[i].GetterToppingCalories(toppingList[i]);
                }


                total += dough.GetterDoughCalories(dough);
                
                
                return total;
            }
        }
    }
}