using LAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface ILAHubDbContext
{
    DbSet<Address> Addresses { get; }
    DbSet<Category> Categories { get; }
    DbSet<Classification> Classifications { get; }
    DbSet<Contact> Contacts { get; }
    DbSet<Eligibility> Eligibilities { get; }
    DbSet<Location> Locations { get; }
    DbSet<OperatingHours> OperatingHours { get; }
    DbSet<Organisation> Organisations { get; }
    DbSet<ServiceArea> ServiceAreas { get; }
    DbSet<ServiceCategory> ServiceCategories { get; }
    DbSet<ServiceClassification> ServiceClassifications { get; }
    DbSet<Service> Services { get; }
    DbSet<ServiceLocation> ServiceLocations { get; }
    DbSet<ServiceOptionCategory> ServiceOptionCategories { get; }
    DbSet<ServiceOptionClassification> ServiceOptionClassifications { get; }
    DbSet<ServiceOptionType> ServiceOptionTypes { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
