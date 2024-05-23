namespace Core.Models
{
    public class BlogTag : AbstractEntity
    {
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
