using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                List<Person> personsList = new List<Person>();
                List<Product> productsList = new List<Product>();

                string[] persons = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < persons.Length; i += 2)
                {
                    string name = persons[i];
                    decimal money = decimal.Parse(persons[i + 1]);

                    Person person = new Person(name, money);

                    personsList.Add(person);
                }

                string[] products = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    decimal price = decimal.Parse(products[i + 1]);

                    Product product = new Product(name, price);

                    productsList.Add(product);
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] info = command.Split();

                    string personName = info[0];
                    string productName = info[1];

                    var currPerson = personsList.FirstOrDefault(x => x.Name == personName);
                    var currProduct = productsList.FirstOrDefault(x => x.Name == productName);

                    currPerson.BuyProduct(currPerson, currProduct);
                }

                foreach (var item in personsList)
                {

                    string result = item.ProductsBought.Count > 0 ? $"{string.Join(", ", item.ProductsBought.Select(x => x.Name))}" : "Nothing bought";
                    Console.WriteLine($"{item.Name} - {result}");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}

