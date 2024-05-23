namespace Infrastructure.Services
{
    public interface IFileService<TEntity, TRequest, TResponse, TExtensionEnum>
        : IService<TEntity, TRequest, TResponse>
        where TEntity : AbstractFile
        where TExtensionEnum : Enum
        where TRequest : EntityRequest
    {
        Task<Core.Response<TResponse>> AddAsync(IFormFile files);
        Task<Core.Response<List<TResponse>>> AddBulkAsync(List<IFormFile> files);
    }
    public class FileService<TEntity, TRequest, TResponse, TExtensionEnum>
        : Service<TEntity, TRequest, TResponse>, IFileService<TEntity, TRequest, TResponse, TExtensionEnum>
        where TEntity : AbstractFile
        where TExtensionEnum : Enum
        where TRequest : EntityRequest
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public FileService(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Core.Response<List<TResponse>>> AddBulkAsync(List<IFormFile> files)
        {
            var records = await FileHelper.WriteBulkFiles<TExtensionEnum>(files, typeof(TEntity).Name);

            List<TEntity> entities = new List<TEntity>();

            foreach (var record in records)
            {
                if (record is not null)
                {
                    var entity = _mapper.Map<TEntity>(record);
                    var result = await _repository.AddAsync(entity);
                    entities.Add(result);
                }
            }

            var response =  _mapper.Map<List<TResponse>>(entities);

            return ResponseHelper.CreateCreatedResponse(response);
        }

        public async Task<Core.Response<TResponse>> AddAsync(IFormFile file)
        {

            var record = await FileHelper.WriteFile<TExtensionEnum>(file, typeof(TEntity).Name);


            if (record is not null)
            {
                var entity = _mapper.Map<TEntity>(record);
                var result = await _repository.AddAsync(entity);
                var response = _mapper.Map<TResponse>(result);
                return ResponseHelper.CreateCreatedResponse(response);

            }
            return null;

        }

        public async Task<Core.Response<bool>> DeleteAsync(Guid id)
        {
            var file = await _repository.FindByIdAsync(id);

            if (file is null)
                return ResponseHelper.CreateNotFoundResponse<bool>
                       ($"No {typeof(TEntity).Name} Found!");

            await _repository.DeleteAsync(file);

            string filepath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload/{typeof(TEntity).Name}/{file.Path}");

            if (File.Exists(filepath))
                File.Delete(filepath);

            return ResponseHelper.CreateSuccessResponse(true);
        }

        public async Task<Core.Response<bool>> BulkDeleteAsync(List<TRequest> requests)
        {
            foreach (var request in requests)
            {
                var file = await _repository.FindByIdAsync(request.Id);

                if (file is null)
                    return ResponseHelper.CreateNotFoundResponse<bool>
                           ($"No {typeof(TEntity).Name} Found!");

                await _repository.DeleteAsync(file);

                string filepath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload/{typeof(TEntity).Name}/{file.Path}");

                if (File.Exists(filepath))
                    File.Delete(filepath);

            }

            return ResponseHelper.CreateSuccessResponse(true);

        }
    }
}
