namespace Core.DTOs
{
    public class AssignmentResponse : AbstractEntity
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
    }
}
