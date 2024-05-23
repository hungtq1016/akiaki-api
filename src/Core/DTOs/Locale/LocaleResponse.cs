namespace Core.DTOs
{
    public class LocaleResponse : AbstractEntity
    {
        public Guid LanguageId { get; set; }
        public Guid KeyId { get; set; }
        public string Value { get; set; }
    }
}
