namespace Core.DTOs
{
    public class PermissionRequest : EntityRequest
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
