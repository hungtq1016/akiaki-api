namespace Core.DTOs
{
    public class TreatmentPlantResponse : AbstractEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid PatientId { get; set; }
        public UserResponse Patient { get; set; }
        public ICollection<TreatmentDetailResponse> Details { get; } = new List<TreatmentDetailResponse>();
    }
}
