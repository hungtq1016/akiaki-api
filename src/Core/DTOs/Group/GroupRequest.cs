namespace Core.DTOs
{
    public class GroupRequest : EntityRequest
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
