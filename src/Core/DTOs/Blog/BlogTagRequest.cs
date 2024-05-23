namespace Core.DTOs
{
    public class BlogTagRequest : EntityRequest
    {
        public Guid TagId { get; set; }
        public Guid BlogId { get; set; }
    }
}
