using System.Security.Claims;

namespace AnimalStudio.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetUserId(this ClaimsPrincipal? userClaimsPrincipal)
        {
            return userClaimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? null;
        }
    }
}
