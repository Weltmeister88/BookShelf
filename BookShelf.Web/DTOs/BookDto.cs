using System.ComponentModel.DataAnnotations;

namespace BookShelf.Web.DTOs
{
    public class BookDto : BookAddDto
    {
        [Required]
        public int Id { get; set; }
        public AuthorAddDto Author { get; set; }
    }
}