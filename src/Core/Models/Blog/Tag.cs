namespace Core.Models
{
    public class Tag : AbstractEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public ICollection<BlogTag> Blogs { get; } = new List<BlogTag>();

    }
}
