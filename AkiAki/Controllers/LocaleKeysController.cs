namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaleKeysController : ResourceController<LocaleKey, PrescriptionRequest, LocaleKeyResponse>
    {
        public LocaleKeysController(IService<LocaleKey, PrescriptionRequest, LocaleKeyResponse> service) : base(service)
        {
        }
    }
}
