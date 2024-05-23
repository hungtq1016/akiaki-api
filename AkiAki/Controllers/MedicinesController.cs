using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ResourceController<Medicine, MedicineRequest, MedicineResponse>
    {
        private readonly IService<Medicine, MedicineRequest, MedicineResponse> _service;
        public MedicinesController(IService<Medicine, MedicineRequest, MedicineResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindUsers([FromQuery] string? value, [FromQuery] PaginationRequest request)
        {
            Expression<Func<Medicine, bool>> condition;

            condition = e => e.Brand.Contains(value) || e.Title.Contains(value);

            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<Medicine, bool>>[] { condition });

            return StatusCode(result.StatusCode, result);
        }
    }
}
