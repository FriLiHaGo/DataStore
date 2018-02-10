using DataStoreDB.Models;
using System.Collections.Generic;

namespace DataStoreDB.Repositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Document GetByName(string name);

        IList<Document> SearchByName(string name);
    }
}
