namespace Infrastructure.Services
{
    public interface IImageService : IFileService<Image,ImageRequest,ImageResponse, ImageExtensionsEnum>
    {
        Core.FileResponse FindByPath(string path);
    }
    public class CImageService : FileService<Image, ImageRequest, ImageResponse, ImageExtensionsEnum>, IImageService
    {
        public CImageService(IRepository<Image> repository, IMapper mapper) : base(repository, mapper){ }

        public Core.FileResponse FindByPath(string path)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload/{typeof(Image).Name}", path);
            string extension = FileHelper.GetExtension(path);
            if (File.Exists(filePath))
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                return new Core.FileResponse
                {
                    FilesBytes = bytes,
                    Extension = extension == "svg" ? "svg+xml" : extension
                };
            }
            else
            {
                return null!;
            }
        }
    }
}
