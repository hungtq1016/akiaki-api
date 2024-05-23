namespace Core.DTOs
{
    public class FaqRequest : EntityRequest
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Src { get; set; }
    }
}
