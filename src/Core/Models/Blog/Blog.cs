namespace Core.Models
{
    public class Blog : AbstractEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string Desc { get; set; }
        public string Content { get; set; }
        public string VideoEmbed { get; set; }

        public ICollection<Comment> Comments { get; } = new List<Comment>();
        public ICollection<BlogTag> Tags { get; } = new List<BlogTag>();
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
