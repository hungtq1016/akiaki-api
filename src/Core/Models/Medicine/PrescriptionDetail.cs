namespace Core.Models
{
    public class PrescriptionDetail : AbstractEntity
    {
        public string Usage { get; set; }
        public int Quantity { get; set; }
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public Guid MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }
}

