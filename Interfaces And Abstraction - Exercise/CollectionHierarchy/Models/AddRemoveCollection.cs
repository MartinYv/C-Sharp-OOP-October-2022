using CollectionHierarchy.Models.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection

    {

        public AddRemoveCollection()
        {
            Collection = new List<string>(100);
        }
        public List<string> Collection { get; set; }

        public int Add(string element)
        {
            Collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string element = Collection[Collection.Count-1];
            Collection.RemoveAt(Collection.Count - 1);
            return element;
        }
    }
}