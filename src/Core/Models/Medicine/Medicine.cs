namespace Core.Models
{
    public class Medicine: AbstractEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Brand { get; set; }
        public string Desc { get; set; }
        public ICollection<PrescriptionDetail> Precriptions { get; } = new List<PrescriptionDetail>();

    }
}
