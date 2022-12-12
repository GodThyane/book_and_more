using Ocelot.Authorization;
using Ocelot.Middleware;

namespace BookAndMore.Gateway.Api.Middleware;

public static class OcelotAuthorizationMiddleware
{
    public static async Task Authorize(HttpContext httpContext, Func<Task> next)
    {
        if (ValidateRole(httpContext) && ValidateScope(httpContext))
            await next.Invoke();
        else
        {
            httpContext.Response.StatusCode = 403;
            httpContext.Items.SetError(new UnauthorizedError($"Fail to authorize"));
        }
    }

    private static bool ValidateScope(HttpContext httpContext)
    {
        var downstreamRoute = httpContext.Items.DownstreamRoute();
        var listOfScopes = downstreamRoute.AuthenticationOptions.AllowedScopes;
        if (listOfScopes == null || listOfScopes.Count == 0) return true;
        var userClaimsPrincipals = httpContext.User.Claims.ToArray();
        var listOfClaimTypes = userClaimsPrincipals.Select(userClaim => userClaim.Type).ToList();
        return listOfScopes.All(scope => listOfClaimTypes.Contains(scope));
    }

    private static bool ValidateRole(HttpContext ctx)
    {
        var downStreamRoute = ctx.Items.DownstreamRoute();
        if (downStreamRoute.AuthenticationOptions.AuthenticationProviderKey == null) return true;
        //This will get the claims of the users JWT
        var userClaims = ctx.User.Claims.ToArray();

        //This will get the required authorization claims of the route
        Dictionary<string, string> requiredAuthorizationClaims = downStreamRoute.RouteClaimsRequirement;

        //Getting the required claims for the route
        return (from requiredAuthorizationClaim in requiredAuthorizationClaims where ValidateIfStringIsRole(requiredAuthorizationClaim.Key) from requiredClaimValue in requiredAuthorizationClaim.Value.Split(",") from userClaim in userClaims where ValidateIfStringIsRole(userClaim.Type) && requiredClaimValue.Equals(userClaim.Value) select requiredClaimValue).Any();
    }

    private static bool ValidateIfStringIsRole(string role)
    {
        // The http://schemas.microsoft.com/ws/2008/06/identity/claims/role string is nesscary because Microsoft returns this as role claims in a JWT
        // And when directly adding this to the ocelot.json it will crash ocelot
        return role.Equals("http://schemas.microsoft.com/ws/2008/06/identity/claims/role") || role.Equals("Role") ||
               role.Equals("role");
    }
}