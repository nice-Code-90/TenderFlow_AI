
using TenderFlow_AI.Domain.Interfaces;

namespace TenderFlow_AI.Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IOrganizationRepository Organizations { get; }
    IOrganizationContextRepository OrganizationContexts { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    bool HasChanges();
}
