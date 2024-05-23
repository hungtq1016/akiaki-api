using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentPlantsController : ResourceController<TreatmentPlant, TreatmentPlantRequest, TreatmentPlantResponse>
    {
        private readonly IService<TreatmentPlant, TreatmentPlantRequest, TreatmentPlantResponse> _service;
        public TreatmentPlantsController(IService<TreatmentPlant, TreatmentPlantRequest, TreatmentPlantResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("search/{id:Guid}")]
        public async Task<IActionResult> FindPageByCondition(Guid id, [FromQuery] TreatmentRequest crequest, [FromQuery] PaginationRequest request)
        {
            if (crequest == null)
            {
                crequest = new TreatmentRequest();
            }

            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<TreatmentPlant, bool>>[]
            {
                g => g.Title.Contains(crequest.Title) &&
                     g.CreatedAt >= crequest.StartFrom &&
                     g.CreatedAt <= crequest.EndFrom &&
                     g.Patient.Id == id
            });

            return StatusCode(result.StatusCode, result);
        }

        public class TreatmentRequest
        {
            public TreatmentRequest()
            {
                StartFrom = DateTime.UtcNow.AddDays(-14);
                EndFrom = DateTime.UtcNow.AddDays(14);
                Title = "";
            }

            public TreatmentRequest(DateTime starFrom, DateTime endFrom, string title, int bloodPressure)
            {
                StartFrom = starFrom;
                EndFrom = endFrom;
                Title = title;
            }

            public DateTime StartFrom { get; set; }
            public DateTime EndFrom { get; set; }
            public string Title { get; set; }
        }
    }
}
