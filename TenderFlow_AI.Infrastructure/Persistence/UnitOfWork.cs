using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Domain.Interfaces;
using TenderFlow_AI.Infrastructure.Persistence.Repositories;
using TenderFlow_AI.Infrastructure.Repositories;

namespace TenderFlow_AI.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly TenderFlowDbContext _context;
    private IOrganizationRepository? _organizations;
    private IOrganizationContextRepository? _organizationContexts;
    private IEmployeeRepository? _employees;
    private ICompanyProjectRepository? _companyProjects;

    public UnitOfWork(TenderFlowDbContext context)
    {
        _context = context;
    }

    public IOrganizationRepository Organizations =>
        _organizations ??= new OrganizationRepository(_context);
    public IOrganizationContextRepository OrganizationContexts => 
        _organizationContexts ??= new OrganizationContextRepository(_context);
    public IEmployeeRepository Employees =>
        _employees ??= new EmployeeRepository(_context);
    public ICompanyProjectRepository CompanyProjects =>
        _companyProjects ??= new CompanyProjectRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public bool HasChanges() => _context.ChangeTracker.HasChanges();

    public void Dispose() => _context.Dispose();
}
