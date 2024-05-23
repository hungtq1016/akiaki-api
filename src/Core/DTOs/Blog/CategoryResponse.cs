namespace Core.DTOs
{
    public class CategoryResponse : AbstractEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public ICollection<BlogCategoryResponse> Blogs { get; } = new List<BlogCategoryResponse>();
    }
}
