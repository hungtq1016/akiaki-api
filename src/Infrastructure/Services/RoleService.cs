
namespace Infrastructure.Services
{
    public interface IRoleService : IService<Role, RoleRequest, RoleResponse>
    {
        Task<Core.Response<List<Role>>> FindAllRolesByUserId(Guid userId); 
        Task<Core.Response<bool>> HasPermission(string permissionRequire, HttpContext context);
        Task<Core.Response<List<Permission>>> GetAllPermissionsAsync(HttpContext context);
    }

    public class RoleService : Service<Role, RoleRequest, RoleResponse>, IRoleService
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IMemoryCache _memoryCache;

        public RoleService(IRepository<Group> groupRepository, IMemoryCache memoryCache, IRepository<Role> roleRepository, IRepository<Permission> permissionRepository, IMapper mapper)
            : base(roleRepository, mapper)
        {
            _groupRepository = groupRepository;
            _permissionRepository = permissionRepository;
            _memoryCache = memoryCache;
        }

        public async Task<Core.Response<List<Role>>> FindAllRolesByUserId(Guid userId)
        {
            var groups = await _groupRepository.FindAllByConditionAsync(conditions: new Expression<Func<Group, bool>>[]
                                                                    {
                                                                        g => g.UserId == userId
                                                                    }, properties: "Role");

            if (groups.Count is 0 || groups is null)
                return ResponseHelper.CreateNotFoundResponse<List<Role>>("No roles found for the specified user.");

            var roles = groups.Select(g => g.Role).Distinct().ToList();

            return ResponseHelper.CreateSuccessResponse(roles);
        }

        public async Task<Core.Response<bool>> HasPermission(string permissionRequire, HttpContext context)
        {
            ClaimsPrincipal principal = context.User;

            var userId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                return ResponseHelper.CreateSuccessResponse(false);
            }

            if (!HasPermission(principal, userId, permissionRequire))
            {
                return ResponseHelper.CreateSuccessResponse(false);
            }
            return ResponseHelper.CreateSuccessResponse(true);
        }

        public async Task<Core.Response<List<Permission>>> GetAllPermissionsAsync(HttpContext context)
        {
            if (context == null)
                return ResponseHelper.CreateErrorResponse<List<Permission>>(403, null);

            var userIdClaim = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim is null || !Guid.TryParse(userIdClaim, out Guid userId))
            {
                return ResponseHelper.CreateSuccessResponse<List<Permission>>(null);
            }

            var permissions = await _permissionRepository.FindAllByConditionAsync(new Expression<Func<Permission, bool>>[]
            {
        e => e.Assignments.Any(a => a.Role.Groups.Any(g => g.UserId == userId))
            });

            return ResponseHelper.CreateSuccessResponse(permissions);
        }

        private bool HasPermission(ClaimsPrincipal principal, string userId, string permission)
        {

            if (!_memoryCache.TryGetValue(userId, out List<Permission> cachePermissions))
            {
                _memoryCache.Set(userId, cachePermissions);
            }

            return CheckPermission(principal, permission);
        }

        private bool CheckPermission(ClaimsPrincipal principal, string permission)
        {
            var permissionsLower = permission.ToLower();

            return principal.Claims.Any(claim =>
                (claim.Type.ToLower() == "controller" && permissionsLower == claim.Value.ToLower() ||
                claim.Type.ToLower() == "permission" && permissionsLower == claim.Value.ToLower() ||
                claim.Type.ToLower() == "admin" && claim.Value.ToLower() == "all"));
        }
    }
}
