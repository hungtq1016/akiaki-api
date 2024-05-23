using System.Linq.Expressions;
using System.Web;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentDetailsController : ResourceController<TreatmentDetail, TreatmentDetailRequest, TreatmentDetailResponse>
    {
        private readonly IService<TreatmentDetail, TreatmentDetailRequest, TreatmentDetailResponse> _service;
        public TreatmentDetailsController(IService<TreatmentDetail, TreatmentDetailRequest, TreatmentDetailResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("treatments/{id:Guid}")]
        public async Task<IActionResult> FindAllBlogs(Guid id)
        {
            var result = await _service.FindAllByConditionAsync(conditions: new Expression<Func<TreatmentDetail, bool>>[]
                                                                    {
                                                                        e => e.TreatmentId == id
                                                                    });
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("client")]
        public async Task<IActionResult> FindAllByCondition([FromQuery] int month, [FromQuery] Guid treatId)
        {

            var result = await _service.FindAllByConditionAsync(conditions: new Expression<Func<TreatmentDetail, bool>>[]
            {
                g => g.Date.Month == month && g.TreatmentId == treatId

            }, "Activity");

            return StatusCode(result.StatusCode, result);
        }
    }
}
