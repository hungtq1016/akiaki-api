
namespace Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : AbstractEntity
    {
        Task<TEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TEntity> FindByParamsAsync(Guid id, params string[] properties);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>>[] conditions, CancellationToken cancellationToken = default);
        Task<int> CountByConditionAsync(Expression<Func<TEntity, bool>>[] conditions);
        Task<TEntity> FindOneByConditionAsync(Expression<Func<TEntity, bool>>[] conditions, params string[] properties);
        Task<List<TEntity>> FindAllByConditionAsync(Expression<Func<TEntity, bool>>[] conditions, params string[] properties);
        Task<PaginationResponse<List<TEntity>>> FindPageByConditionAsync(PaginationRequest request, Expression<Func<TEntity, bool>>[] conditions, params string[] properties);
        Task<PaginationResponse<List<TEntity>>> FindPageAsync(PaginationRequest request);
        Task<List<TEntity>> FindAllAsync(params string[] properties);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> EditAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<List<TEntity>> BulkEditAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
        ValueTask DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        ValueTask BulkDeleteAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
        IQueryable<TEntity> Query();
        Task<TEntity> FindRandomAsync();
    }
}
