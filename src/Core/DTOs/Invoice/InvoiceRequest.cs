namespace Core.DTOs
{
    public class InvoiceRequest : EntityRequest
    {
        public double Total { get; set; }
        public double Tax { get; set; }

        public Guid PatientId { get; set; }
        public Guid NurseId { get; set; }
        public Guid HealthRecordId { get; set; }
    }
}
