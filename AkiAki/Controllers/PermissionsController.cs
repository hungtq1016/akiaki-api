namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ResourceController<Permission, PermissionRequest, PermissionResponse>
    {
        private readonly IPermissionService _permissionService;
        public PermissionsController(IPermissionService service) : base(service)
        {
            _permissionService = service;
        }

        [HttpGet("ByRoleId/{roleId:Guid}")]
        public async Task<IActionResult> GetPermissionsByRoleId(Guid roleId)
        {
            var response = await _permissionService.FindAllPermissionsByRoleId(roleId);
            return StatusCode(response.StatusCode, response);
        }
    }
}
