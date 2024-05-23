namespace Core.DTOs
{
    public class TreatmentDetailResponse : AbstractEntity
    {
        public DateTime Date { get; set; }
        public Guid TreatmentId { get; set; }
        public TreatmentPlantResponse Treatment { get; set; }
        public Guid ActivityId { get; set; }
        public ActivityResponse Activity { get; set; }
    }
}
