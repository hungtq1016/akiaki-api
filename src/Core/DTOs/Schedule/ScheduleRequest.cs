namespace Core.DTOs
{
    public class ScheduleRequest : EntityRequest
    {
        public DateTime Date { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Time { get; set; }
        public string Email { get; set; }
        public string Desc { get; set; }

        public Guid BranchId { get; set; }
        public Guid ServiceId { get; set; }
    }
}
