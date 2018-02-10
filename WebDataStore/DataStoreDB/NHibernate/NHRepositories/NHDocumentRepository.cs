using DataStoreDB.Models;
using DataStoreDB.Repositories;
using System.Collections.Generic;

namespace DataStoreDB.NHibernate.NHRepositories
{
    public class NHDocumentRepository : NHBaseRepository<Document>, IDocumentRepository
    {
        public Document GetByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Document>()
                    .And(d => d.Name == name)
                    .SingleOrDefault();
            }
        }

        public IList<Document> SearchByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return session.QueryOver<Document>()
                        .WhereRestrictionOn(d => d.Name)
                        .IsLike($"%{name}%")
                        .List();
                }
                return GetAll();
            }
        }
    }
}
