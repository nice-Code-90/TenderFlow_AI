using Microsoft.AspNetCore.Http;
using TenderFlow_AI.Application.Common.Interfaces;

namespace TenderFlow_AI.Infrastructure.Services
{
    public class HttpTenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpTenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetTenantId()
        {
            
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null) return Guid.Empty;

            if (httpContext.Request.Headers.TryGetValue("X-Organization-Id", out var headerValue))
            {
                if (Guid.TryParse(headerValue, out var tenantId))
                {
                    return tenantId;
                }
            }

            
            var routeValues = httpContext.Request.RouteValues;
            if (routeValues != null && routeValues.TryGetValue("organizationId", out var routeId))
            {
                if (Guid.TryParse(routeId?.ToString(), out var parsedRouteId))
                {
                    return parsedRouteId;
                }
            }

            return Guid.Empty;
        }
    }
}
