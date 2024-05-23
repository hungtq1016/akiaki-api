namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ResourceController<Tag, TagRequest, TagResponse>
    {
        public TagsController(IService<Tag, TagRequest, TagResponse> service) : base(service)
        {
        }
    }
}
