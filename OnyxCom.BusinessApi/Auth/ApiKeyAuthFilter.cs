using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnyxCom.BusinessApi.Auth
{
    public class ApiKeyAuthFilter : Attribute, IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;
        public ApiKeyAuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(AppConstants.ApiAuthHeader, out var apiKeySent))
            {
                context.Result = new UnauthorizedObjectResult("Please provide an API Key.");
                return;
            }

            string apiKeySaved = _configuration.GetValue<string>(AppConstants.ApiKeyConfigSection);

            if (!apiKeySaved.Equals(apiKeySent, StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new UnauthorizedObjectResult("Invalid API Key.");
                return;
            }
        }
    }
}
