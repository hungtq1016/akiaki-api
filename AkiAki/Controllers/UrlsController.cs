namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ResourceController<Url, UrlRequest, UrlResponse>
    {
        public UrlsController(IService<Url, UrlRequest, UrlResponse> service) : base(service)
        {
        }
    }
}
