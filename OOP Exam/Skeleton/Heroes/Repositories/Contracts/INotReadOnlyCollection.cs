using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories.Contracts
{
   public interface INotReadOnlyCollection<T>
    {
        public List<T> Collection { get; set; }
        
    }
}
