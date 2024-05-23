using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ResourceController<Blog, BlogRequest, BlogResponse>
    {
        IService<Blog, BlogRequest, BlogResponse> _service;
        public BlogsController(IService<Blog, BlogRequest, BlogResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("{id:Guid}")]
        public override async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.FindOneByConditionAsync(conditions: new Expression<Func<Blog, bool>>[]
                                                                    {
                                                                        e => e.Id == id
                                                                    }, properties: "Category");
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> FindOneByCondition(string slug, [FromQuery] bool show)
        {
            var result = await _service.FindOneByConditionAsync(conditions: new Expression<Func<Blog, bool>>[]
                                                                    {
                                                                        g => g.Slug == slug && (!g.Category.Slug.Contains("root") || show),
                                                                    }, properties:"Category");
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("category/{slug}")]
        public async Task<IActionResult> FindBlogs(string slug, [FromQuery] PaginationRequest request)
        {
            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<Blog, bool>>[]
                                                                    {
                                                                        g => g.Category.Slug == slug
                                                                    });
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindUsers([FromQuery] string? value, [FromQuery] PaginationRequest request)
        {
            Expression<Func<Blog, bool>> condition;

            condition = e => (e.Title.Contains(value));

            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<Blog, bool>>[] { condition });

            return StatusCode(result.StatusCode, result);
        }
    }
}
