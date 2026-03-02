using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Domain.Entities;
using TenderFlow_AI.Domain.Interfaces;

namespace TenderFlow_AI.Infrastructure.Persistence;

public class TenderFlowDbContext : DbContext
{
    private readonly ITenantProvider _tenantProvider;
    public Guid CurrentOrganizationId => _tenantProvider.GetTenantId();

    public TenderFlowDbContext(
        DbContextOptions<TenderFlowDbContext> options,
        ITenantProvider tenantProvider) : base(options)
    {
        _tenantProvider = tenantProvider;
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
                if (entry.Entity.OrganizationId == Guid.Empty)
                {
                    entry.Entity.OrganizationId = CurrentOrganizationId;
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    private LambdaExpression CreateTenantFilterExpression(Type type)
    {
        var parameter = Expression.Parameter(type, "e");
        var property = Expression.Property(parameter, nameof(ITenantEntity.OrganizationId));
        
        var dbContextInstance = Expression.Constant(this);
        var tenantIdProperty = Expression.Property(dbContextInstance, nameof(CurrentOrganizationId));

        var equal = Expression.Equal(property, tenantIdProperty);
        return Expression.Lambda(equal, parameter);
    }
}