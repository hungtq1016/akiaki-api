namespace Core.Models
{
    public class Faq : AbstractEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Src { get; set; }
    }
}
