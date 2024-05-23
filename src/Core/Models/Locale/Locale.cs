namespace Core.Models
{
    public class Locale : AbstractEntity
    {
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
        public Guid KeyId { get; set; }
        public LocaleKey Key { get; set; }
        public string Value { get; set; }
    }
}
