namespace Core.DTOs
{
    public class LanguageRequest : EntityRequest
    {
        public string Label { get; set; }
        public string Code { get; set; }
    }
}
