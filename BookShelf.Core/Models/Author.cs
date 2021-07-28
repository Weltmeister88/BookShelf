using System.Collections.Generic;

namespace BookShelf.Core.Models
{
    public class Author : AuditedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public ICollection<Book> Books { get; set; }
    }
}