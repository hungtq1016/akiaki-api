namespace Core.DTOs
{
    public class TreatmentDetailRequest : EntityRequest
    {
        public DateTime Date { get; set; }
        public Guid TreatmentId { get; set; }
        public Guid ActivityId { get; set; }
    }
}
