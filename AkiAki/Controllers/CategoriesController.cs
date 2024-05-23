using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ResourceController<Category, CategoryRequest, CategoryResponse>
    {
        IService<Category, CategoryRequest, CategoryResponse> _service;
        public CategoriesController(IService<Category, CategoryRequest, CategoryResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("blogs")]
        public async Task<IActionResult> FindAllBlogs()
        {
            var result = await _service.FindAllByConditionAsync(conditions: new Expression<Func<Category, bool>>[]
                                                                    { 
                                                                        e => !e.Title.Contains("root")
                                                                    }, "Blogs");
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            var result = await _service.FindAllByConditionAsync(conditions: new Expression<Func<Category, bool>>[]
                                                                    {
                                                                        e => !e.Title.Contains("root")
                                                                    });
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("admin")]
        public async Task<IActionResult> GetByAdmin()
        {
            var result = await _service.FindAllAsync();
            return StatusCode(result.StatusCode, result);
        }


        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> FindOneByCondition(string slug)
        {
            var result = await _service.FindOneByConditionAsync(conditions: new Expression<Func<Category, bool>>[]
                                                                    {
                                                                        g => g.Slug == slug
                                                                    });
            return StatusCode(result.StatusCode, result);
        }
    }
}
