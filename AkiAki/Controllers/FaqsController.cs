using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqsController : ResourceController<Faq, FaqRequest, FaqResponse>
    {
        private readonly IService<Faq, FaqRequest, FaqResponse> _service;
        public FaqsController(IService<Faq, FaqRequest, FaqResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("src/{src}")]
        public async Task<IActionResult> Get(string src)
        {
            var result = await _service.FindAllByConditionAsync(new Expression<Func<Faq, bool>>[]
                                                                    {
                                                                        g => g.Src == src
                                                                    });
            return StatusCode(result.StatusCode, result);
        }
    }
}
