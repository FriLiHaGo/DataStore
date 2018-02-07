using DataStoreDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreDB.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Boolean Check(string login, string password);

        User GetByLogin(string login);
    }
}
