using DataStoreDB.Models;
using DataStoreDB.Repositories;
using System.Collections.Generic;

namespace DataStoreDB.NHibernate.NHRepositories
{
    public class NHBaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        public void Delete(long id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var obj = session.Get<T>(id);
                    if (obj != null)
                    {
                        session.Delete(obj);
                        transaction.Commit();
                    }
                }
            }
        }

        public T Get(long id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public IList<T> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<T>().List();
            }
        }

        public void Save(T item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(item);
                    transaction.Commit();
                }
            }
        }
    }
}
