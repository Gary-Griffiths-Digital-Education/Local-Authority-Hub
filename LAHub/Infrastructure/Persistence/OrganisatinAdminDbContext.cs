using System.Reflection;
using LAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrganisationAdmin.Infrastructure.Persistence;

public class OrganisatinAdminDbContext : DbContext
{
    public OrganisatinAdminDbContext(DbContextOptions<OrganisatinAdminDbContext> options)
          : base(options)
    {
    }

    public DbSet<Organisation> Organisations => Set<Organisation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
