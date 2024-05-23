namespace Core.Models
{
    public class GroupUrl : AbstractEntity
    {
        public string Label { get; set; }
        public ICollection<Url> Urls { get; } = new List<Url>();

    }
}
