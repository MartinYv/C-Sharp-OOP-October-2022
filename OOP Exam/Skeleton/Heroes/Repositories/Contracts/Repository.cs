using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories.Contracts
{
    public class Repository : IRepository<IHero>
    {
        public Repository()
        {
        }

        public IReadOnlyCollection<IHero> Models => Collection;
        public List<IHero> Collection { get; set; }

        public void Add(IHero model)
        {
            Collection.Add(model);
        }

        public IHero FindByName(string name)
        {
            var isContain = Collection.FirstOrDefault(x => x.Name == name);
            return isContain;
        }

        public bool Remove(IHero model)
        {
            var isContain = Collection.FirstOrDefault(x => x.Name == model.Name);
            if (isContain != null)
            {
            Collection.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
