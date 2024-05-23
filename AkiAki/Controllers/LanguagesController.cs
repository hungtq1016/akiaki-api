namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ResourceController<Language, LanguageRequest, LanguageResponse>
    {
        public LanguagesController(IService<Language, LanguageRequest, LanguageResponse> service) : base(service)
        {
        }
    }
}
