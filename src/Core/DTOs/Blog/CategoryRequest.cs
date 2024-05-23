namespace Core.DTOs
{
    public class CategoryRequest : EntityRequest
    {
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
