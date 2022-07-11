using LAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface ILAHubDbContext
{
    DbSet<Category> Categories { get; }
    DbSet<Contact> Contacts { get; }
    DbSet<Eligibility> Eligibilities { get; }
    DbSet<Organisation> Organisations { get; }
    DbSet<Service> Services { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
