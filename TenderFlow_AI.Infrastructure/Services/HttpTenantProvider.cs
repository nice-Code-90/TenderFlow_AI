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
            
            var tenantIdHeader = _httpContextAccessor.HttpContext?.Request.Headers["X-Tenant-Id"].ToString();

            if (Guid.TryParse(tenantIdHeader, out var tenantId))
            {
                return tenantId;
            }

            
            var routeValues = _httpContextAccessor.HttpContext?.Request.RouteValues;
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
