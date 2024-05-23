namespace Infrastructure.Builders
{
    public class ResponseBuilder<TEntity>
    {
        private Core.Response<TEntity> response = new Core.Response<TEntity>();

        public ResponseBuilder(TEntity data)
        {
            response.Data = data;
        }

        public ResponseBuilder()
        {
            response.Data = default;
        }

        public ResponseBuilder<TEntity> WithStatusCode(int code)
        {
            response.StatusCode = code;
            return this;
        }

        public ResponseBuilder<TEntity> WithMessage(string message)
        {
            response.Message = message;
            return this;
        }

        public ResponseBuilder<TEntity> WithError()
        {
            response.IsError = true;
            return this;
        }
        public ResponseBuilder<TEntity> With500(string message = "The Server Encountered!")
        {
            response.Message = message;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            response.IsError = true;
            return this;
        }

        public ResponseBuilder<TEntity> With404(string message =  $"{nameof(TEntity)} Not Found!")
        {
            response.Message = message;
            response.StatusCode = (int)HttpStatusCode.NotFound;
            response.IsError = true;
            response.Data = default;
            return this;
        }

        public ResponseBuilder<TEntity> With201()
        {
            response.Message = ((StatusMessageEnum)HttpStatusCode.Created).ToString();
            response.StatusCode = (int)HttpStatusCode.Created;
            response.IsError = false;
            return this;
        }

        public ResponseBuilder<TEntity> With200()
        {
            response.Message = ((StatusMessageEnum)HttpStatusCode.OK).ToString();
            response.StatusCode = (int)HttpStatusCode.OK;
            response.IsError = false;
            return this;
        }

        public Core.Response<TEntity> Build()
        {
            return response;
        }
    }
}
