namespace Core.DTOs
{
    public class PrescriptionResponse : AbstractEntity
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
    }
}
