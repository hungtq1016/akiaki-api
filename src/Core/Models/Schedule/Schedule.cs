namespace Core.Models
{
    public class Schedule : AbstractEntity
    {
        public DateTime Date { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Time { get; set; }
        public string Email { get; set; }
        public string Desc { get; set; }

        public Guid BranchId { get; set; }
        public Branch Branch { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
