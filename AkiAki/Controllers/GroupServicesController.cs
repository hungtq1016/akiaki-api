using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupServicesController : ResourceController<GroupService, GroupServiceRequest, GroupServiceResponse>
    {
        private readonly IService<GroupService, GroupServiceRequest, GroupServiceResponse> _service;
        public GroupServicesController(IService<GroupService, GroupServiceRequest, GroupServiceResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("label/{label}")]
        public async Task<IActionResult> FindOneByCondition(string label)
        {
            var result = await _service.FindOneByConditionAsync(conditions: new Expression<Func<GroupService, bool>>[]
                                                                    {
                                                                        g => g.Label == label
                                                                    }, properties: "Services");
            return StatusCode(result.StatusCode, result);
        }
    }
}
