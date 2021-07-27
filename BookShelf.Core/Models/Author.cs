using System.Collections.Generic;

namespace BookShelf.Core.Models
{
    public class Author : AuditedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}