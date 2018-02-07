using DataStoreDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreDB.Repositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Document GetByName(string name);
    }
}
