using System.ComponentModel.DataAnnotations;
using BookShelf.Core.Models;

namespace BookShelf.Web.DTOs
{
    public abstract class BookBaseDto{
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public Genre? Genre { get; set; }
    }
}