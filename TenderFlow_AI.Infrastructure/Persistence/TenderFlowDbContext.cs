using Microsoft.EntityFrameworkCore;
using TenderFlow_AI.Domain.Entities;

namespace TenderFlow_AI.Infrastructure.Persistence;

public class TenderFlowDbContext : DbContext
{
    public TenderFlowDbContext(DbContextOptions<TenderFlowDbContext> options) : base(options)
    {
    }

    public DbSet<Tender> Tenders { get; set; }
    public DbSet<Requirement> Requirements { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<CompanyProject> CompanyProjects { get; set; }
    public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
    public DbSet<TenderConstraint> TenderConstraints { get; set; }
    public DbSet<ProjectAttribute> ProjectAttributes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenderFlowDbContext).Assembly);
    }
}
