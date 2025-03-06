using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using HomeSafeServiceProviderNetwork.WebApi.Interfaces.Config;

namespace HomeSafeServiceProviderNetwork.WebApi
{
    public class AuthorizationHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();
        private readonly ISecurityConfig _securityConfig;

        public AuthorizationHandler(ISecurityConfig securityConfig)
        {
            _securityConfig = securityConfig;
        }

        public async Task HandleAsync(
            RequestDelegate next,
            HttpContext context,
            AuthorizationPolicy policy,
            PolicyAuthorizationResult authorizeResult)
        {

            var allowedUsers = _securityConfig.AllowedUsers;

            if (context.User != null && context.User.Identity.IsAuthenticated)
            {
                if (allowedUsers.Contains(context.User.Identity.Name))
                {
                    await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
                    return;
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return;
                }
            }

            await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
    }

    public class Show404Requirement : IAuthorizationRequirement { }
}
