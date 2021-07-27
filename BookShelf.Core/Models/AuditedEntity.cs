using System;

namespace BookShelf.Core.Models
{
    public abstract class AuditedEntity : Entity
    {
        public DateTime CreatedUtc { get; set; }
        public DateTime ModifiedUtc { get; set; }
    }
}