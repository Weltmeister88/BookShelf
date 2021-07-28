using System.ComponentModel.DataAnnotations;

namespace BookShelf.Web.DTOs
{
    public class AuthorDto : AuthorAddDto
    {
        [Required]
        public int Id { get; set; }
    }
}