namespace BookShelf.Web.DTOs
{
    public class SelectItemDto<TId>
    {
        public TId Id { get; set; }
        public string Description { get; set; }
    }
}