using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Filters
{
    public class TokenRequiredAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null || jwtToken.ValidTo < DateTime.UtcNow)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }

    /*public class TokenRequiredFilter : IAuthorizationFilter
    {
        private readonly ITokenService _tokenService;

        public TokenRequiredFilter(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context == null || context.HttpContext == null) return;

            var userId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (context.HttpContext.User.Claims == null || string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

        }
    }*/
}
