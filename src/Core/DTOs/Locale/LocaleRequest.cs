namespace Core.DTOs
{
    public class LocaleRequest : EntityRequest
    {
        public Guid LanguageId { get; set; }
        public Guid KeyId { get; set; }
        public string Value { get; set; }
    }
}
