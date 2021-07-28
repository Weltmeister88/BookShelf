namespace BookShelf.Web.DTOs
{
    public class SelectItemDto<TId, TValue>
    {
        public TId Id { get; set; }
        public TValue Value { get; set; }

        public SelectItemDto()
        {
        }

        public SelectItemDto(TId id, TValue value)
        {
            Id = id;
            Value = value;
        }
    }
}