namespace Core.DTOs
{
    public class TagRequest : EntityRequest
    {
        public string Title { get; set; }
        public string Slug { get; set; }

    }
}
