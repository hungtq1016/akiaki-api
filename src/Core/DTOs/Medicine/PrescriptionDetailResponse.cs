using Core.Models;

namespace Core.DTOs
{
    public class PrescriptionDetailResponse : AbstractEntity
    {
        public Guid PrescriptionId { get; set; }
        public Guid MedicineId { get; set; }
        public MedicineResponse Medicine { get; set; }
        public string Usage { get; set; }
        public string Quantity { get; set; }
    }
}
