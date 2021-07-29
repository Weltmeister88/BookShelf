using System.ComponentModel.DataAnnotations;

namespace BookShelf.Web.DTOs
{
    public class BookEditDto : BookBaseDto
    {
        public int Id { get; set; }
        [Required]
        public int? AuthorId { get; set; }
    }
}