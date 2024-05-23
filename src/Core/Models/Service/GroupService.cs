namespace Core.Models
{
    public class GroupService : AbstractEntity
    {
        public string Label { get; set; }
        public string Slug { get; set; }
        public ICollection<Service> Services { get; } = new List<Service>();

    }
}
