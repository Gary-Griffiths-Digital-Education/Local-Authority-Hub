using LAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface ILAHubDbContext
{
    DbSet<Tenant> Tenants { get; }
    DbSet<Address> Addresses { get; }
    DbSet<Classification> Classifications { get; }
    DbSet<Contact> Contacts { get; }
    DbSet<Location> Locations { get; }
    DbSet<Organisation> Organisations { get; }
    DbSet<OrganisationType> OrganisationTypes { get;}
    DbSet<Service> Services { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
