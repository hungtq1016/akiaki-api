namespace Core.Models
{
    public class Prescription: AbstractEntity
    {
        public Guid DoctorId { get; set; }
        public User Doctor { get; set; }
        public Guid PatientId { get; set; }
        public User Patient { get; set; }
        public ICollection<PrescriptionDetail> Details { get; } = new List<PrescriptionDetail>();
    }
}

