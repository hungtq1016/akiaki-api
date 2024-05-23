namespace Core.Models
{
    public class TreatmentPlant : AbstractEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid PatientId { get; set; }
        public User Patient { get; set; }
        public ICollection<TreatmentDetail> Details { get; } = new List<TreatmentDetail>();
    }
}
