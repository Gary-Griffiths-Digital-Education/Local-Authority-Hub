using LAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrganisationAdmin.Infrastructure.Persistence;

namespace OrganisationAdmin.IntegrationTests.Persistence;

public abstract class BaseEfRepositoryTestFixture
{
    protected OrganisatinAdminDbContext _dbContext;

    protected BaseEfRepositoryTestFixture()
    {
        var options = CreateNewContextOptions();
        _dbContext = new OrganisatinAdminDbContext(options);
    }

    protected static DbContextOptions<OrganisatinAdminDbContext> CreateNewContextOptions()
    {
        // Create a fresh service provider, and therefore a fresh
        // InMemory database instance.
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        // Create a new options instance telling the context to use an
        // InMemory database and the new service provider.
        var builder = new DbContextOptionsBuilder<OrganisatinAdminDbContext>();
        builder.UseInMemoryDatabase("local_authority_hub")
               .UseInternalServiceProvider(serviceProvider);

        return builder.Options;
    }

    protected EfRepository<Organisation> GetRepository()
    {
        return new EfRepository<Organisation>(_dbContext);
    }
}
