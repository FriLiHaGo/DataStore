using DataStoreDB.Models;

namespace DataStoreDB.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByName(string roleName);
    }
}
