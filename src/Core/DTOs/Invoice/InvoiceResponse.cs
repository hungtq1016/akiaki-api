namespace Core.DTOs
{
    public class InvoiceResponse : AbstractEntity
    {
        public double Total { get; set; }
        public double Tax { get; set; }

        public Guid PatientId { get; set; }
        public UserResponse Patient { get; set; }
        public Guid NurseId { get; set; }
        public UserResponse Nurse { get; set; }
        public Guid HealthRecordId { get; set; }

        public ICollection<InvoiceDetailResponse>? InvoiceDetails { get; } = new List<InvoiceDetailResponse>();

    }
}
