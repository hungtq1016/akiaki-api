using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
    {

        public DBContext CreateDbContext(string[] args)
        {
            /*var connectionString = ConfigurationHelper.GetConfiguration(AppContext.BaseDirectory)
                ?.GetConnectionString("db.base");*/
            //var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=db.AkiAki;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            var connectionString = "Data Source=SQL8010.site4now.net,1433;Initial Catalog=db_aa87a9_hungtq1016;User Id=db_aa87a9_hungtq1016_admin;Password=H#ng123789;";

            Console.WriteLine($"Connectiong string: {connectionString}");

            var optionsBuilder = new DbContextOptionsBuilder<DBContext>()
                .UseSqlServer(
                    connectionString ?? throw new InvalidOperationException(),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(GetType().Assembly.FullName);
                        sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
                    }
                );

            return (DBContext)Activator.CreateInstance(typeof(DBContext), optionsBuilder.Options);
        }
    }
}
