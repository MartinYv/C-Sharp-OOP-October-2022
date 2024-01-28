using CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
   public class AddColection : IAddCollection
    {
        public AddColection()
        {
            Collection = new List<string>(100);
        }
        public List<string> Collection { get; set; }
        

        public int Add(string element)
        {
            Collection.Add(element);
            return Collection.Count-1;
        }
        
    }
}
