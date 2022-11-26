using DataStoreDB.Models;
using DataStoreDB.Repositories;

namespace DataStoreDB.NHibernate.NHRepositories
{
    public class NHRoleRepository : NHBaseRepository<Role>, IRoleRepository
    {
        public Role GetByName(string roleName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Role>()
                    .And(u => u.Name == roleName)
                    .SingleOrDefault();
            }
        }
    }
}
