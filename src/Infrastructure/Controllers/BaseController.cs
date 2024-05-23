using Infrastructure.Filters;

namespace Infrastructure.Controllers
{
    public abstract class SingletonController<TEntity, TRequest, TResponse> : ControllerBase where TEntity : AbstractEntity where TRequest : EntityRequest
    {
        private readonly IService<TEntity, TRequest, TResponse> _service;
        public SingletonController(IService<TEntity, TRequest, TResponse> service)
        {
            _service = service;
        }

        [HttpGet]
    
        public virtual async Task<IActionResult> Get()
        {
            var result = await _service.FindAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("page")]
        public virtual async Task<IActionResult> GetPage([FromQuery] PaginationRequest request)
        {
            var result = await _service.FindPageAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("random")]
        public virtual async Task<IActionResult> GetRandom()
        {
            var result = await _service.FindRandomAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:Guid}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.FindByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        [TokenRequired]
        public virtual async Task<IActionResult> Post([FromBody] TRequest request)
        {
            var result = await _service.AddAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:Guid}")]
        [TokenRequired]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
    public abstract class ResourceController<TEntity, TRequest, TResponse> : SingletonController<TEntity, TRequest, TResponse> where TEntity : AbstractEntity where TRequest : EntityRequest
    {
        private readonly IService<TEntity, TRequest, TResponse> _service;
        protected ResourceController(IService<TEntity, TRequest, TResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpPut("{id:Guid}")]
        [TokenRequired]
        public virtual async Task<IActionResult> Put(Guid id, [FromBody] TRequest request)
        {
            var result = await _service.EditAsync(id, request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        [TokenRequired]
        public virtual async Task<IActionResult> BulkPut([FromBody] List<TRequest> requests)
        {
            var result = await _service.BulkEditAsync(requests);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete]
        [TokenRequired]
        public virtual async Task<IActionResult> BulkDelete([FromBody] List<TRequest> request)
        {
            var result = await _service.BulkDeleteAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("count")]
        public virtual async Task<IActionResult> CountByTimeUnit([FromQuery] string? timePeriod)
        {
            var result = await _service.CountByTimeUnitAsync(timePeriod);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("compare-count")]
        public virtual async Task<IActionResult> CompareCount([FromQuery] string? timePeriod)
        {
            var result = await _service.CompareCountAsync(timePeriod);
            return StatusCode(result.StatusCode, result);
        }
    }
}
