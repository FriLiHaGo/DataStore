using DataStoreDB.Models;
using DataStoreDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
