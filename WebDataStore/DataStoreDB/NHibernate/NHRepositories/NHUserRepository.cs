using DataStoreDB.Models;
using DataStoreDB.Repositories;
namespace DataStoreDB.NHibernate.NHRepositories
{
    public class NHUserRepository : NHBaseRepository<User>, IUserRepository
    {
        public bool Check(string login, string password)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>()
                    .And(u => u.Password == password)
                    .And(u => u.Login == login)
                    .And(u => u.Status == UserStatus.Active || u.Status == UserStatus.System)
                    .RowCount() == 1;
            }
        }

        public User GetByLogin(string login)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>()
                    .And(u => u.Login == login)
                    .SingleOrDefault();
            }
        }
    }
}
