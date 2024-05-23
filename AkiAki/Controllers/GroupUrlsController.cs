using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupUrlsController : ResourceController<GroupUrl, GroupUrlRequest, GroupUrlResponse>
    {
        private readonly IService<GroupUrl, GroupUrlRequest, GroupUrlResponse> _service;
        public GroupUrlsController(IService<GroupUrl, GroupUrlRequest, GroupUrlResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("label/{label}")]
        public virtual async Task<IActionResult> FindOneByCondition(string label)
        {
            var result = await _service.FindOneByConditionAsync(conditions: new Expression<Func<GroupUrl, bool>>[]
                                                                    {
                                                                        g => g.Label == label
                                                                    }, properties: "Urls");
            return StatusCode(result.StatusCode, result);
        }
    }
}
