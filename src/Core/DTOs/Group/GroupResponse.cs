namespace Core.DTOs
{
    public class GroupResponse : AbstractEntity
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
