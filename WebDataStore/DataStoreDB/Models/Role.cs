namespace DataStoreDB.Models
{
    public class Role : IEntity
    {
        #region IEntity

        public virtual long Id { get; set; }

        #endregion

        public virtual string Name { get; set; }
    }
}
