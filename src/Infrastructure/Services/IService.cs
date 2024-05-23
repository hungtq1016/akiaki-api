namespace Infrastructure.Services
{
    public interface IService<TEntity, TRequest, TResponse>
    {
        Task<Core.Response<PaginationResponse<List<TResponse>>>> FindPageAsync(PaginationRequest request);
        Task<Core.Response<PaginationResponse<List<TResponse>>>> FindPageByConditionAsync(PaginationRequest request, Expression<Func<TEntity, bool>>[] conditions, params string[] properties);
        Task<Core.Response<List<TResponse>>> FindAllAsync(params string[] properties);
        Task<Core.Response<List<TResponse>>> FindAllByConditionAsync(Expression<Func<TEntity, bool>>[] conditions, params string[] properties);
        Task<Core.Response<PaginationResponse<List<TResponse>>>> FindPageByTimeUnitAsync(PaginationRequest request, string timePeriod, params string[] properties);
        Task<Core.Response<int>> CountByTimeUnitAsync(string timePeriod);
        Task<Core.Response<TResponse>> FindByIdAsync(Guid id);
        Task<Core.Response<TResponse>> FindByParamsAsync(Guid id, params string[] properties);
        Task<Core.Response<TResponse>> FindOneAsync(Expression<Func<TEntity, bool>>[] conditions);
        Task<Core.Response<TResponse>> FindOneByConditionAsync(Expression<Func<TEntity, bool>>[] conditions, params string[] properties);
        Task<Core.Response<TResponse>> AddAsync(TRequest request);
        Task<Core.Response<TResponse>> EditAsync(Guid id, TRequest request);
        Task<Core.Response<List<TResponse>>> BulkEditAsync(List<TRequest> request);
        Task<Core.Response<bool>> DeleteAsync(Guid id);
        Task<Core.Response<bool>> BulkDeleteAsync(List<TRequest> request);
        Task<Core.Response<Dictionary<string, Dictionary<int, int>>>> CompareCountAsync(string timePeriod);
        Task<Core.Response<TResponse>> FindRandomAsync();
    }
}
