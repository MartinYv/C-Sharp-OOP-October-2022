using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models.Interfaces
{
  public interface IAddCollection
    {

        public List<string> Collection { get; set; }
        public int Add(string element);
    }
}
