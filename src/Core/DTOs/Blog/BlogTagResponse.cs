namespace Core.DTOs
{
    public class BlogTagResponse : AbstractEntity
    {
        public Guid TagId { get; set; }

        public Guid BlogId { get; set; }
    }
}
