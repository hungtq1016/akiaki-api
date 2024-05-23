namespace Core.Models
{
    public class Invoice : AbstractEntity
    {
        public double Total { get; set; }
        public double Tax { get; set; }

        public Guid PatientId { get; set; }
        public User Patient { get; set; }
        public Guid NurseId { get; set; }
        public User Nurse { get; set; }
        public Guid HealthRecordId { get; set; }
        public HealthRecord HealthRecord { get; set; }
        public ICollection<InvoiceDetail>? InvoiceDetails { get; } = new List<InvoiceDetail>();

    }
}
