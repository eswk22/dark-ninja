using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public abstract class Entity : IEntity
    {
        public Entity()
        {
            Id = string.Empty;
        }
        public virtual string Id { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual long CreatedOn { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual long ModifiedOn { get; set; }

    }
}
