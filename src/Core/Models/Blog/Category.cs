namespace Core.Models
{
    public class Category : AbstractEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public ICollection<Blog> Blogs { get; } = new List<Blog>();
    }
}
