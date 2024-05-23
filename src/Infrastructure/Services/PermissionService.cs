namespace Infrastructure.Services
{
    public interface IPermissionService : IService<Permission, PermissionRequest, PermissionResponse>
    {
        Task<Core.Response<List<Permission>>> FindAllPermissionsByRoleId(Guid roleId);
    }

    public class PermissionService : Service<Permission, PermissionRequest, PermissionResponse>, IPermissionService
    {
        private readonly IRepository<Assignment> _assignRepository;

        public PermissionService(IRepository<Assignment> assignRepository, IRepository<Permission> roleRepository, IMapper mapper)
            : base(roleRepository, mapper)
        {
            _assignRepository = assignRepository;
        }

        public async Task<Core.Response<List<Permission>>> FindAllPermissionsByRoleId(Guid roleId)
        {
            var assignments = await _assignRepository.FindAllByConditionAsync(conditions: new Expression<Func<Assignment, bool>>[]
                                                                    {
                                                                        g => g.RoleId == roleId
                                                                    }, properties: "Permission");

            if (assignments.Count is 0 || assignments is null)
                return ResponseHelper.CreateNotFoundResponse<List<Permission>>("No permissions found for the specified user.");

            var permissions = assignments.Select(g => g.Permission).Distinct().ToList();

            return ResponseHelper.CreateSuccessResponse(permissions);
        }

    }
}
