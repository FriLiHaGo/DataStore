namespace DataStoreDB.Models
{
    public class User :IEntity
    {
        #region IEntity

        public virtual long Id { get; set; }

        #endregion

        public virtual string Name { get; set; }

        public virtual string Sername { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual UserStatus Status { get; set; }

        public virtual Role Role { get; set; }
    }

    public enum UserStatus
    {
        Deleted = 0,
        Active = 1,
        Blocked = 2,
        System = 3
    }
}
