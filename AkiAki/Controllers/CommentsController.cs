using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ResourceController<Comment, CommentRequest, CommentResponse>
    {
        private readonly IService<Comment, CommentRequest, CommentResponse> _service;
        public CommentsController(IService<Comment, CommentRequest, CommentResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("blog/{id:Guid}")]
        public async Task<IActionResult> FindAllCommentsByBlog(Guid id, [FromQuery] PaginationRequest request)
        {
            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<Comment, bool>>[]
                                                                    {
                                                                        e => e.Blog.Id == id && e.ParentId == e.Id
                                                                    },"User");
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("user/{id:Guid}")]
        public async Task<IActionResult> FindAllCommentsByUser(Guid id, [FromQuery] PaginationRequest request)
        {
            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<Comment, bool>>[]
                                                                    {
                                                                        e => e.User.Id == id
                                                                    });
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("comment/{id:Guid}")]
        public async Task<IActionResult> FindAllCommentsByParent(Guid id, [FromQuery] PaginationRequest request)
        {
            var result = await _service.FindPageByConditionAsync(request, conditions: new Expression<Func<Comment, bool>>[]
                                                                    {
                                                                        e => e.Parent.Id == id && e.Id != id
                                                                    });
            return StatusCode(result.StatusCode, result);
        }
    }
}
