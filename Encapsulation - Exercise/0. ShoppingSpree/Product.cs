using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
   public class Product
    {
        private string name;
        private decimal cost;
        private List<Product> products;

        public Product(string name, decimal cost)
        {
            products = new List<Product>();

            Name = name;
            Cost = cost;
        }
        public string Name
        {
            get { return name; }
          private  set { name = value; }
        }
        public decimal Cost
        {
            get { return cost; }
          private  set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value; 
            }
        }

        public IReadOnlyCollection< Product> Products
        {

            get { return products; }
            
        }

        public void AddProduct(string name, Product product)
        {
            if (!products.Contains(product))
            {
                products.Add(product);
            }
        }
    }
}
