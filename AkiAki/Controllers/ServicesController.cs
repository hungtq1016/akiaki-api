using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ResourceController<Service, ServiceRequest, ServiceResponse>
    {
        private readonly IService<Service, ServiceRequest, ServiceResponse> _service;
        public ServicesController(IService<Service, ServiceRequest, ServiceResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> FindOneByCondition(string slug)
        {
            var result = await _service.FindOneByConditionAsync(conditions: new Expression<Func<Service, bool>>[]
                                                                    {
                                                                        g => g.Slug == slug
                                                                    });
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("group/{slug}")]
        public async Task<IActionResult> FindAllServices(string slug, [FromQuery] PaginationRequest request)
        {
            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<Service, bool>>[]
                                                                    {
                                                                        g => g.Group.Slug == slug
                                                                    });
            return StatusCode(result.StatusCode, result);
        }
    }
}
