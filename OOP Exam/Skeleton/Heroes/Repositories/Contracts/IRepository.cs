namespace Heroes.Repositories.Contracts
{
    using System.Collections.Generic;
    public interface IRepository<T> : INotReadOnlyCollection<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T model);

        bool Remove(T model);

        T FindByName(string name);
    }
}
