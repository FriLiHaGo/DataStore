using DataStoreDB.Models;
using System;

namespace DataStoreDB.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Boolean Check(string login, string password);

        User GetByLogin(string login);
    }
}
