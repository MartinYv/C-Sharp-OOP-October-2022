using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models.Interfaces
{
    public interface IMyList
    {
        public List<string> Collection { get; set; }

        public int Add(string element);
        public string Remove();
        public void Used();
    }
}
