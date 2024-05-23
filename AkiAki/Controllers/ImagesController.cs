namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : FileController<Image, ImageRequest, ImageResponse, ImageExtensionsEnum>
    {
        private readonly IImageService _service;

        public ImagesController(IImageService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("{path}")]
        public IActionResult GetByPath(string path)
        {
            Core.FileResponse result = _service.FindByPath(path);

            if (result is null)
                return NotFound();

            return base.File(result.FilesBytes, $"{typeof(Image).Name}/{result.Extension}");
        }
    }
}
