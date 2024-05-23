namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalesController : ResourceController<Locale, LocaleRequest, LocaleResponse>
    {
        private readonly ILocaleService _service;

        public LocalesController(ILocaleService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("language/{langCode}")]
        public async Task<IActionResult> GetLocales(string langCode)
        {
            var response = await _service.GetLocales(langCode);
            return StatusCode(response.StatusCode, response);
        }
    }
}
