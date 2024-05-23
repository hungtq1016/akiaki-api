using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ResourceController<User, UserRequest, UserResponse>
    {
        private readonly IService<User, UserRequest, UserResponse> _service;
        public UsersController(IService<User, UserRequest, UserResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("role/{role}/search")]
        public async Task<IActionResult> FindUsers(string role,[FromQuery] string? value, [FromQuery] PaginationRequest request)
        {
            Expression<Func<User, bool>> condition;
            if (role == "all")
            {
                if (string.IsNullOrEmpty(value))
                {
                    condition = e => true; // No specific condition, get all users
                }
                else
                {
                    condition = e => e.Email.Contains(value) || e.FullName.Contains(value) || e.PhoneNumber.Contains(value);
                }
            }

            if (string.IsNullOrEmpty(value))
            {
                condition = e => e.Groups.Any(g => g.Role.Name == role);
            }
            else
            {
                condition = e => e.Groups.Any(g => g.Role.Name == role) &&
                                 (e.Email.Contains(value) || e.FullName.Contains(value) || e.PhoneNumber.Contains(value));
            }

            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<User, bool>>[] { condition });

            return StatusCode(result.StatusCode, result);
        }

    }

}
