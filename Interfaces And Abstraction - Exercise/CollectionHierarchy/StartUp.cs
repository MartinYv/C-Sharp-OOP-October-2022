using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Interfaces;
using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IAddCollection addCollection = new AddColection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myListCollection = new MyList();

            string[] text = Console.ReadLine().Split();
            int removeOperations = int.Parse(Console.ReadLine());


            for (int i = 0; i < text.Length; i++)
            {
                Console.Write($"{addCollection.Add(text[i])} ");               
            }

            Console.WriteLine();
           
            for (int i = 0; i < text.Length; i++)
            {                
                Console.Write($"{addRemoveCollection.Add(text[i])} ");           
            }

            Console.WriteLine();

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write($"{myListCollection.Add(text[i])} ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write($"{addRemoveCollection.Remove()} ");           
            }

            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write($"{myListCollection.Remove()} ");
     
            }
        }
    }
}
