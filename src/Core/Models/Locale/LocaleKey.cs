namespace Core.Models
{
    public class LocaleKey : AbstractEntity
    {
        public string Key { get; set; }
        public ICollection<Locale> Locales { get; } = new List<Locale>();
    }
}
