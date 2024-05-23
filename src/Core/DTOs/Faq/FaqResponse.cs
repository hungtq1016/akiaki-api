namespace Core.DTOs
{
    public class FaqResponse : AbstractEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Src { get; set; }
    }
}
