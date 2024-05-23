namespace Core.DTOs
{
    public class GroupServiceRequest : EntityRequest
    {
        public string Label { get; set; }
        public string Slug { get; set; }

    }
}
