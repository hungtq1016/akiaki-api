namespace Core.DTOs 
{
    public class ServiceRequest : EntityRequest
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string VideoEmbed { get; set; }
        public string Desc { get; set; }
        public string Content { get; set; }
        public Guid GroupId { get; set; }
    }
}
