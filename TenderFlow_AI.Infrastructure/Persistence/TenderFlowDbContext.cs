using Microsoft.EntityFrameworkCore;
using TenderFlow_AI.Domain.Entities;
using TenderFlow_AI.Domain.Interfaces;

namespace TenderFlow_AI.Infrastructure.Persistence;

public class TenderFlowDbContext : DbContext
{
    // In a real SaaS, this would be provided by a TenantService from the HTTP Context
    private readonly Guid _currentOrganizationId;

    public TenderFlowDbContext(
        DbContextOptions<TenderFlowDbContext> options,
        Guid currentOrganizationId = default) : base(options)
    {
        _currentOrganizationId = currentOrganizationId;
    }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationContext> OrganizationContexts { get; set; }
    public DbSet<Tender> Tenders { get; set; }
    public DbSet<Requirement> Requirements { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<CompanyProject> CompanyProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ITenantEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .HasQueryFilter(CreateTenantFilterExpression(entityType.ClrType));
            }
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenderFlowDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Automatically sets OrganizationId upon saving new entities.
    /// </summary>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<ITenantEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.OrganizationId = _currentOrganizationId;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    private System.Linq.Expressions.LambdaExpression CreateTenantFilterExpression(Type type)
    {
        var parameter = System.Linq.Expressions.Expression.Parameter(type, "e");
        var property = System.Linq.Expressions.Expression.Property(parameter, nameof(ITenantEntity.OrganizationId));
        var equal = System.Linq.Expressions.Expression.Equal(property, System.Linq.Expressions.Expression.Constant(_currentOrganizationId));
        return System.Linq.Expressions.Expression.Lambda(equal, parameter);
    }
}