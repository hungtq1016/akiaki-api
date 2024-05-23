namespace Core.DTOs
{
    public class TreatmentPlantRequest : EntityRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid PatientId { get; set; }
    }
}
