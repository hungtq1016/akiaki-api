using Infrastructure.Middlewares;

namespace Infrastructure.Extensions
{
    public static class HttpStatusExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
