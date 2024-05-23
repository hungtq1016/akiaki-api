namespace Core.Models
{
    public class Branch : AbstractEntity
    {
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string AddressEmbed { get; set; }
        public string? Name { get; set; }

        public Guid TypeId { get; set; }
        public BranchType Type { get; set; }
        public ICollection<Schedule>? Schedules { get; } = new List<Schedule>();
    }
}
