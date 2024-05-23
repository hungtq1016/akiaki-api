using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthRecordsController : ResourceController<HealthRecord, HealthRecordRequest, HealthRecordResponse>
    {
        private readonly IService<HealthRecord, HealthRecordRequest, HealthRecordResponse> _service;
        public HealthRecordsController(IService<HealthRecord, HealthRecordRequest, HealthRecordResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("search/{id:Guid}")]
        public async Task<IActionResult> FindPageByCondition(Guid id, [FromQuery]RecordRequest crequest,[FromQuery] PaginationRequest request)
        {
            if (crequest == null)
            {
                crequest = new RecordRequest(); 
            }

            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<HealthRecord, bool>>[]
            {
                g => g.HeartBeat >= crequest.HeartBeat &&
                     g.BloodPressure >= crequest.BloodPressure &&
                     g.CreatedAt >= crequest.StartFrom &&
                     g.CreatedAt <= crequest.EndFrom &&
                     g.Patient.Id == id
            });

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("user/{id:Guid}")]
        public async Task<IActionResult> FindPageByUser(Guid id, [FromQuery] PaginationRequest request)
        {
 
            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<HealthRecord, bool>>[]
            {
                g => g.Patient.Id == id
            });

            return StatusCode(result.StatusCode, result);
        }

        public override async Task<IActionResult> GetById(Guid id)
        {
            string[] properties = new string[] { "Invoices", "User" };

            var result = await _service.FindOneByConditionAsync(new Expression<Func<HealthRecord, bool>>[]
            {
                g => g.Id == id
            }, properties);
            return StatusCode(result.StatusCode, result);
        }
    }

    public class RecordRequest
    {
        public RecordRequest()
        {
            StartFrom = DateTime.UtcNow.AddDays(-14);
            EndFrom = DateTime.UtcNow.AddDays(14);
            HeartBeat = 0;
            BloodPressure = 0;
        }

        public RecordRequest(DateTime starFrom, DateTime endFrom, int heartBeat, int bloodPressure)
        {
            StartFrom = starFrom;
            EndFrom = endFrom;
            HeartBeat = heartBeat;
            BloodPressure = bloodPressure;
        }

        public DateTime StartFrom { get; set; }
        public DateTime EndFrom { get; set; }
        public int HeartBeat { get; set; }
        public int BloodPressure { get; set; }
    }
}
