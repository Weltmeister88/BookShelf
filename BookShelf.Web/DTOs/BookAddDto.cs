using System.ComponentModel.DataAnnotations;
using BookShelf.Core.Models;

namespace BookShelf.Web.DTOs
{
    public class BookAddDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}