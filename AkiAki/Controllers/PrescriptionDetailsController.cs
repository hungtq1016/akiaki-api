using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionDetailsController : ResourceController<PrescriptionDetail, PrescriptionDetailRequest, PrescriptionDetailResponse>
    {
        IService<PrescriptionDetail, PrescriptionDetailRequest, PrescriptionDetailResponse> _service;
        public PrescriptionDetailsController(IService<PrescriptionDetail, PrescriptionDetailRequest, PrescriptionDetailResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("prescription/{id:Guid}")]
        public async Task<IActionResult> FindAllBlogs(Guid id)
        {
            var result = await _service.FindAllByConditionAsync(conditions: new Expression<Func<PrescriptionDetail, bool>>[]
                                                                    {
                                                                        e => e.PrescriptionId == id
                                                                    });
            return StatusCode(result.StatusCode, result);
        }
    }
}
