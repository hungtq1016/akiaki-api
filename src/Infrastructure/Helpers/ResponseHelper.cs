using Infrastructure.Builders;

namespace Infrastructure.Helpers
{
    public class ResponseHelper
    {
        public static Core.Response<TEntity> CreateSuccessResponse<TEntity>(TEntity data)
        {
            return new ResponseBuilder<TEntity>(data).With200().Build();
        }

        public static Core.Response<TEntity> CreateCreatedResponse<TEntity>(TEntity data)
        {
            return new ResponseBuilder<TEntity>(data).With201().Build();
        }

        public static Core.Response<TEntity> CreateNotFoundResponse<TEntity>(string message)
        {
            return new ResponseBuilder<TEntity>().With404(message).Build();
        }

        public static Core.Response<TEntity> CreateErrorResponse<TEntity>(int statuscode, string message)
        {
            return new ResponseBuilder<TEntity>().WithStatusCode(statuscode).WithMessage(message).Build();
        }
    }
}
