namespace Core.DTOs
{
    public class BranchResponse : AbstractEntity
    {
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string AddressEmbed { get; set; }
        public string? Name { get; set; }

        public Guid TypeId { get; set; }
    }
}
