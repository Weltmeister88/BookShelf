using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace BookShelf.Web.DTOs
{
    public class BookEditDto : BookBaseDto
    {
        [IgnoreMap]
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}