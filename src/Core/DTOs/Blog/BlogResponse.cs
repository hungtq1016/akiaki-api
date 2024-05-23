namespace Core.DTOs
{
    public class BlogResponse : AbstractEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string Desc { get; set; }
        public string Content { get; set; }
        public string VideoEmbed { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryBlogResponse? Category { get; set; }
    }
}
