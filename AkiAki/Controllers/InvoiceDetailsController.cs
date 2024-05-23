using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailsController : ResourceController<InvoiceDetail, InvoiceDetailRequest, InvoiceDetailResponse>
    {
        private readonly IService<InvoiceDetail, InvoiceDetailRequest, InvoiceDetailResponse> _service;
        public InvoiceDetailsController(IService<InvoiceDetail, InvoiceDetailRequest, InvoiceDetailResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("invoice/{id:Guid}")]
        public async Task<IActionResult> FindAllByCondition(Guid id)
        {
            var result = await _service.FindAllByConditionAsync(conditions: new Expression<Func<InvoiceDetail, bool>>[]
                                                                    {
                                                                        g => g.Invoice.Id == id
                                                                    }, "ServicePrice");
            return StatusCode(result.StatusCode, result);
        }
    }
}
