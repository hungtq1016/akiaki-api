namespace Core.Models
{
    public class Url : AbstractEntity
    {
        public string Label { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string Tag { get; set; }

        public Guid GroupId { get; set; }
        public GroupUrl Group { get; set; }
    }
}
