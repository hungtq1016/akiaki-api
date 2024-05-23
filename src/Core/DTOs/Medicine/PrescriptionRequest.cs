namespace Core.DTOs
{
    public class PrescriptionRequest : EntityRequest
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
    }
}
