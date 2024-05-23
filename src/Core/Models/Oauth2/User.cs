namespace Core.Models
{
    public class User : AbstractEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Group>? Groups { get; } = new List<Group>();
        public ICollection<Token> Tokens { get; } = new List<Token>();
        public ICollection<Comment> Comments { get; } = new List<Comment>();
        public ICollection<Prescription>? Documents { get; } = new List<Prescription>();
        public ICollection<Prescription>? MedicalRecords { get; } = new List<Prescription>();
        public ICollection<HealthRecord>? PatientRecords { get; } = new List<HealthRecord>();
        public ICollection<HealthRecord>? DoctorRecords { get; } = new List<HealthRecord>();
        public ICollection<Invoice>? Nurses { get; } = new List<Invoice>();
        public ICollection<Invoice>? Pantients { get; } = new List<Invoice>();
        public ICollection<TreatmentPlant>? Plants { get; } = new List<TreatmentPlant>();

    }
}
