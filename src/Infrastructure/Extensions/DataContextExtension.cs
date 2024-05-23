﻿

using Nest;

namespace Infrastructure.Extensions
{
    public static class DataContextExtension
    {
        public static IServiceCollection AddSqlServerDbContext<TDbContext>(this IServiceCollection services,
            string connString)
                where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(options =>
            {
                options.UseSqlServer(connString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(TDbContext).Assembly.GetName().Name);
                });
            });
            services.AddScoped(typeof(IService<,,>), typeof(Service<,,>));
            services.AddScoped(typeof(Repository.IRepository<>), typeof(RepositoryBase<>));
            services.AddSingleton<IUriService, UriService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://elasticsearch:9200")));

            var settings = new ConnectionSettings(new Uri("http://elasticsearch:9200"));

            services.AddSingleton<IElasticClient>(new ElasticClient(settings));

            return services;
        }

    }
}
