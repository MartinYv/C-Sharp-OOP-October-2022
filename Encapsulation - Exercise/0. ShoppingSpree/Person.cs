using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> productsBought;

        public Person(string name, decimal money)
        {
            productsBought = new List<Product>();

            Name = name;
            Money = money;
        }
        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> ProductsBought
        {
            get { return productsBought; }

        }

        public void BuyProduct(Person person, Product product)
        {
            if (person.Money - product.Cost >= 0)
            {
                person.Money -= product.Cost;

                person.productsBought.Add(product);

                Console.WriteLine($"{person.Name} bought {product.Name}");

            }
            else
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
        }
    }
}