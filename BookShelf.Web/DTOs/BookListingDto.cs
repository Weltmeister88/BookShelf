using System;

namespace BookShelf.Web.DTOs
{
    public class BookListingDto : BookBaseDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Modified { get; set; }
    }
}