using DataStoreDB.Models;
using System.Collections.Generic;

namespace DataStoreDB.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        void Save(T item);

        void Delete(long id);

        T Get(long id);

        IList<T> GetAll();
    }
}
