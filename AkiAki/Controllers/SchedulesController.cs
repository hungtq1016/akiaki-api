using System.Linq.Expressions;
using System.Web;

namespace Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ResourceController<Schedule, ScheduleRequest, ScheduleResponse>
    {
        private readonly IService<Schedule, ScheduleRequest, ScheduleResponse> _service;
        public SchedulesController(IService<Schedule, ScheduleRequest, ScheduleResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("client")]
        public async Task<IActionResult> FindOneByCondition([FromQuery] DateTime date, [FromQuery] string email)
        {

            var result = await _service.FindOneByConditionAsync(conditions: new Expression<Func<Schedule, bool>>[]
            {
                g => date.Date == g.Date.Date && HttpUtility.UrlDecode(email) == g.Email
                    
            }, new string[] { "Branch", "Service" });

            return StatusCode(result.StatusCode, result);
        }
    }
}
