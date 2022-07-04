using Ardalis.Specification.EntityFrameworkCore;
using LAHub.Domain.Interfaces;

namespace OrganisationAdmin.Infrastructure.Persistence;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(OrganisatinAdminDbContext dbContext) : base(dbContext)
    {
    }
}
