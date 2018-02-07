using System;

namespace DataStoreDB.Models
{
    public class Document : IEntity
    {
        #region IEntity

        public virtual long Id { get; set; }

        #endregion

        public virtual string Name { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual User Author { get; set; }

        public virtual Byte[] FileBin { get; set; }
    }
}
