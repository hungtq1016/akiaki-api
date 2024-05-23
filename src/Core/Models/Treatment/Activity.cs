namespace Core.Models
{
    public class Activity : AbstractEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<TreatmentDetail> Details { get; } = new List<TreatmentDetail>();
    }
}
