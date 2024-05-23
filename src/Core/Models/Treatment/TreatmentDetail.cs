namespace Core.Models
{
    public class TreatmentDetail : AbstractEntity
    {
        public DateTime Date { get; set; }
        public Guid TreatmentId { get; set; }
        public TreatmentPlant Treatment { get; set; }
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
