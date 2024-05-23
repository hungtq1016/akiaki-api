using Infrastructure.Data;
using Nest;

namespace Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : AbstractEntity
    {
        protected readonly DBContext _context;
        protected readonly DbSet<TEntity> _entity;
        private readonly IMemoryCache _cache;
        private readonly string _indexName;
        private readonly IElasticClient _elasticClient;

        public RepositoryBase(DBContext context, IMemoryCache cache, IElasticClient elasticClient)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entity = context.Set<TEntity>();
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _elasticClient = elasticClient ?? throw new ArgumentNullException(nameof(elasticClient));
            _indexName = typeof(TEntity).Name.ToLower();
        }

        public async Task<TEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (!_cache.TryGetValue(id, out TEntity entity))
            {
                entity = await _entity.FindAsync(new object[] { id }, cancellationToken);
                if (entity != null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                    _cache.Set(id, entity, cacheEntryOptions);
                }
            }
            return entity;
        }

        public async Task<TEntity> FindRandomAsync()
        {
            int count = await _entity.CountAsync();
            int index = new Random().Next(count);
            return await _entity.Skip(index).FirstOrDefaultAsync();
        }

        public async Task<TEntity> FindByParamsAsync(Guid id, params string[] properties)
        {
            return await IncludeProperties(_entity, properties).FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>>[] conditions, CancellationToken cancellationToken = default)
        {
            return await ApplyConditions(_entity, conditions).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> CountByConditionAsync(Expression<Func<TEntity, bool>>[] conditions)
        {
            return await ApplyConditions(_entity, conditions).CountAsync();
        }

        public async Task<TEntity> FindOneByConditionAsync(Expression<Func<TEntity, bool>>[] conditions, params string[] properties)
        {
            var query = ApplyConditions(IncludeProperties(_entity, properties), conditions);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> FindAllByConditionAsync(Expression<Func<TEntity, bool>>[] conditions, params string[] properties)
        {
            var query = ApplyConditions(IncludeProperties(_entity, properties), conditions);
            return await query.ToListAsync();
        }

        public async Task<PaginationResponse<List<TEntity>>> FindPageAsync(PaginationRequest request)
        {
            IQueryable<TEntity> query = _entity;

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = ApplySearch(query, request.Search);
            }

            int totalRecords = await query.CountAsync();

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                query = ApplyOrderBy(query, request.SortBy, request.SortOrder);
            }

            var pagedData = await query.Skip((request.PageNumber - 1) * request.PageSize)
                                        .Take(request.PageSize)
                                        .ToListAsync();

            return PaginationHelper<TEntity>.GeneratePaginationResponse(pagedData, request, totalRecords);
        }

        public async Task<PaginationResponse<List<TEntity>>> FindPageByConditionAsync(PaginationRequest request, Expression<Func<TEntity, bool>>[] conditions, params string[] properties)
        {
            var query = ApplyConditions(IncludeProperties(_entity, properties), conditions);

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = ApplySearch(query, request.Search);
            }

            int totalRecords = await query.CountAsync();

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                query = ApplyOrderBy(query, request.SortBy, request.SortOrder);
            }

            var pagedData = await query.Skip((request.PageNumber - 1) * request.PageSize)
                                        .Take(request.PageSize)
                                        .ToListAsync();

            return PaginationHelper<TEntity>.GeneratePaginationResponse(pagedData, request, totalRecords);
        }

        public async Task<List<TEntity>> FindAllAsync(params string[] properties)
        {
            return await IncludeProperties(_entity, properties).ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _entity.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            await _elasticClient.IndexAsync(entity, idx => idx.Index(_indexName));

            return entity;
        }

        public async ValueTask DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _entity.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            await _elasticClient.DeleteAsync<TEntity>(entity.Id, idx => idx.Index(_indexName));
        }

        public async Task<TEntity> EditAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (!_context.Set<TEntity>().Local.Any(e => e.Id == entity.Id))
            {
                _context.Set<TEntity>().Attach(entity);
            }

            entity.UpdatedAt = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);

            await _elasticClient.UpdateAsync<TEntity, object>(entity.Id, u => u.Doc(entity).Index(_indexName));

            return entity;
        }

        public async Task<List<TEntity>> BulkEditAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                await EditAsync(entity, cancellationToken);
            }
            return entities;
        }

        public async ValueTask BulkDeleteAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _entity.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);

            foreach (var entity in entities)
            {
                await _elasticClient.DeleteAsync<TEntity>(entity.Id, idx => idx.Index(_indexName));
            }
        }

        public IQueryable<TEntity> Query() => _entity;

        private IQueryable<TEntity> ApplyConditions(IQueryable<TEntity> query, Expression<Func<TEntity, bool>>[] conditions)
        {
            if (conditions != null)
            {
                foreach (var condition in conditions)
                {
                    query = query.Where(condition);
                }
            }
            return query;
        }

        private IQueryable<TEntity> IncludeProperties(IQueryable<TEntity> query, string[] properties)
        {
            if (properties != null)
            {
                foreach (var include in properties)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        private IQueryable<TEntity> ApplySearch(IQueryable<TEntity> query, string search)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var properties = typeof(TEntity).GetProperties();
            Expression searchExpression = null;

            foreach (var property in properties)
            {
                var propertyAccess = Expression.Property(parameter, property);
                Expression containsExpression = null;

                if (property.PropertyType == typeof(string))
                {
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var searchTermExpression = Expression.Constant(search);
                    containsExpression = Expression.Call(propertyAccess, containsMethod, searchTermExpression);
                }
                else if (property.PropertyType.IsNumericType())
                {
                    if (double.TryParse(search, out double numericSearchTerm))
                    {
                        containsExpression = Expression.Equal(propertyAccess, Expression.Constant(numericSearchTerm));
                    }
                }
                else if (property.PropertyType == typeof(Guid))
                {
                    if (Guid.TryParse(search, out Guid guidSearchTerm))
                    {
                        containsExpression = Expression.Equal(propertyAccess, Expression.Constant(guidSearchTerm));
                    }
                    else
                    {
                        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var searchTermExpression = Expression.Constant(search);
                        var guidToStringMethod = property.PropertyType.GetMethod("ToString", Type.EmptyTypes);
                        var guidToStringExpression = Expression.Call(propertyAccess, guidToStringMethod);
                        containsExpression = Expression.Call(guidToStringExpression, containsMethod, searchTermExpression);
                    }
                }

                if (containsExpression != null)
                {
                    if (searchExpression == null)
                    {
                        searchExpression = containsExpression;
                    }
                    else
                    {
                        searchExpression = Expression.OrElse(searchExpression, containsExpression);
                    }
                }
            }

            if (searchExpression != null)
            {
                var lambda = Expression.Lambda<Func<TEntity, bool>>(searchExpression, parameter);
                query = query.Where(lambda);
            }

            return query;
        }

        private IQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> query, string sortBy, SortOrderEnum sortOrder)
        {
            if (!string.IsNullOrEmpty(sortBy) && query.PropertyExists(sortBy))
            {
                return sortOrder == SortOrderEnum.DESC ? query.OrderByPropertyDescending(sortBy) : query.OrderByProperty(sortBy);
            }
            return query;
        }
    }

    public static class TypeExtensions
    {
        public static bool IsNumericType(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }

        public static bool PropertyExists<TEntity>(this IQueryable<TEntity> source, string propertyName)
        {
            return typeof(TEntity).GetProperty(propertyName) != null;
        }
    }
}
