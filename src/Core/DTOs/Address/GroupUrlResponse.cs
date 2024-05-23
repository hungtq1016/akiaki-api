namespace Core.DTOs
{
    public class GroupUrlResponse : AbstractEntity
    {
        public string Label { get; set; }
        public ICollection<UrlResponse> Urls { get; } = new List<UrlResponse>();

    }
}
