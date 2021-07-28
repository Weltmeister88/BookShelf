using System.ComponentModel.DataAnnotations;

namespace BookShelf.Web.DTOs
{
    public class AuthorAddDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}