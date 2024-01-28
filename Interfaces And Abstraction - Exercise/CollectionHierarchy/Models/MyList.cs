using CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        public MyList()
        {
            Collection = new List<string>(100);
        }
        public List<string> Collection { get; set; }

        public int Add(string element)
        {
            Collection.Insert(0,element);
            return 0;
        }

        public string Remove()
        {

            string element = Collection[0];
            Collection.RemoveAt(0);
            return element;
        }

        public void Used()
        {
            foreach (var item in Collection)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
