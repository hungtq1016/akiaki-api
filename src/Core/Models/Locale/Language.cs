namespace Core.Models
{
    public class Language : AbstractEntity
    {
        public string Label { get; set; }
        public string Code { get; set; }
        public ICollection<Locale> Locales { get; } = new List<Locale>();
    }
}
