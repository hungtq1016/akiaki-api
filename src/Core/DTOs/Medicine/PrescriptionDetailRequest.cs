namespace Core.DTOs
{
    public class PrescriptionDetailRequest : EntityRequest
    {
        public string Usage { get; set; }
        public int Quantity { get; set; }
        public Guid PrescriptionId { get; set; }
        public Guid MedicineId { get; set; }
    }
}
