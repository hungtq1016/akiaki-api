namespace Core.DTOs
{
    public class GroupServiceResponse : AbstractEntity
    {
        public string Label { get; set; }
        public string Slug { get; set; }
        public ICollection<ServiceResponse> Services { get; } = new List<ServiceResponse>();

    }
}
