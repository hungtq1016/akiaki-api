using Infrastructure.Filters;
using Microsoft.AspNetCore.Authorization;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ResourceController<Role, RoleRequest, RoleResponse>
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService) : base(roleService)
        {
            _roleService = roleService;
        }


        [HttpGet("ByUserId/{userId:Guid}")]
        public async Task<IActionResult> GetRolesByUserId(Guid userId)
        {
            var response = await _roleService.FindAllRolesByUserId(userId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("has-permission")]
        [TokenRequired]
        public async Task<IActionResult> HasPermission([FromBody] string permission)
        {
            var response = await _roleService.HasPermission(permission, HttpContext);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("permissions")]
        [TokenRequired]
        public async Task<IActionResult> GetAllPermissions()
        {
            var response = await _roleService.GetAllPermissionsAsync(HttpContext);
            return StatusCode(response.StatusCode, response);
        }
    }
}
