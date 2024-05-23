using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ResourceController<Invoice, InvoiceRequest, InvoiceResponse>
    {
        private readonly IService<Invoice, InvoiceRequest, InvoiceResponse> _service;
        private readonly IInvoiceService _invoiceService;
        public InvoicesController(IService<Invoice, InvoiceRequest, InvoiceResponse> service, IInvoiceService invoiceService) : base(service)
        {
            _service = service;
            _invoiceService = invoiceService;
        }

        [HttpGet("user/{id:Guid}")]
        public async Task<IActionResult> FindPageByCondition(Guid id, [FromQuery] CInvoiceRequest crequest, [FromQuery] PaginationRequest request)
        {
            if (crequest == null)
            {
                crequest = new CInvoiceRequest();
            }

            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<Invoice, bool>>[]
            {
                g => g.Total >= crequest.Total &&
                     g.CreatedAt >= crequest.StartFrom &&
                     g.CreatedAt <= crequest.EndFrom &&
                     g.PatientId == id
            },"Nurse");

            return StatusCode(result.StatusCode, result);
        }

        public override async Task<IActionResult> GetById(Guid id)
        {
            string[] properties = new string[]{ "InvoiceDetails.ServicePrice", "Patient", "Nurse" };

            var result = await _service.FindOneByConditionAsync(new Expression<Func<Invoice, bool>>[]
            {
                g => g.Id == id
            }, properties);
            return StatusCode(result.StatusCode, result);
        }

        public class CInvoiceRequest
        {
            public CInvoiceRequest()
            {
                StartFrom = DateTime.UtcNow.AddDays(-14);
                EndFrom = DateTime.UtcNow.AddDays(14);
                Total = 0;
            }

            public CInvoiceRequest(DateTime starFrom, DateTime endFrom, int total)
            {
                StartFrom = starFrom;
                EndFrom = endFrom;
                Total = total;
            }

            public DateTime StartFrom { get; set; }
            public DateTime EndFrom { get; set; }
            public int Total { get; set; }
        }

        [HttpGet("total")]
        public async Task<IActionResult> TotalByUnitTime([FromQuery] string? timePeriod)
        {
            try
            {
                var totals = await _invoiceService.TotalByUnitTimeAsync(timePeriod);
                return Ok(totals);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("compare-total")]
        public async Task<IActionResult> CompareTotal([FromQuery] string? timePeriod)
        {
            try
            {
                var totals = await _invoiceService.CompareTotalAsync(timePeriod);
                return Ok(totals);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
