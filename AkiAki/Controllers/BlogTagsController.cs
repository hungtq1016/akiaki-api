using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTagsController : SingletonController<BlogTag, BlogTagRequest, BlogTagResponse>
    {
        IService<BlogTag, BlogTagRequest, BlogTagResponse> _service;
        public BlogTagsController(IService<BlogTag, BlogTagRequest, BlogTagResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("blogs/{id:Guid}")]
        public async Task<IActionResult> FindAllBlogs(Guid id)
        {
            var result = await _service.FindAllByConditionAsync(conditions: new Expression<Func<BlogTag, bool>>[]
                                                                    {
                                                                        e => e.BlogId == id
                                                                    });
            return StatusCode(result.StatusCode, result);
        }


        [HttpGet("tags/{id:Guid}")]
        public async Task<IActionResult> FindAllTags(Guid id)
        {
            var result = await _service.FindAllByConditionAsync(conditions: new Expression<Func<BlogTag, bool>>[]
                                                                    {
                                                                        e => e.TagId == id
                                                                    });
            return StatusCode(result.StatusCode, result);
        }
    }
}
