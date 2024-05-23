namespace Core.DTOs
{
    public class MedicineRequest : EntityRequest
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Brand { get; set; }
        public string Desc { get; set; }
    }
}
