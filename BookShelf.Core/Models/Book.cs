namespace BookShelf.Core.Models
{
    public class Book : AuditedEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}