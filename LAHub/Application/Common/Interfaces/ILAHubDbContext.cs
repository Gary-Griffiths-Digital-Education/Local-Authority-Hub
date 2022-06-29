using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface ILAHubDbContext
{
    DbSet<AddressDto> Addresses { get; }
    DbSet<CategoryDto> Categories { get; }
    DbSet<ClassificationDto> Classifications { get; }
    DbSet<ContactDto> Contacts { get; }
    DbSet<ContactMechanismDto> ContactMechanisms { get; }
    DbSet<ContactMechanismTypeDto> ContactMechanismTypes { get; }
    DbSet<EligibilityDto> Eligibilities { get; }
    DbSet<LocationDto> Locations { get; }
    DbSet<OperatingHoursDto> OperatingHours { get; }
    DbSet<OrganisationDto> Organisations { get; }
    DbSet<ServiceAreaDto> ServiceAreas { get; }
    DbSet<ServiceCategoryDto> ServiceCategories { get; }
    DbSet<ServiceClassificationDto> ServiceClassifications { get; }
    DbSet<ServiceDto> Services { get; }
    DbSet<ServiceLocationDto> ServiceLocations { get; }
    DbSet<ServiceOptionCategoryDto> ServiceOptionCategories { get; }
    DbSet<ServiceOptionClassificationDto> ServiceOptionClassifications { get; }
    DbSet<ServiceOptionTypeDto> ServiceOptionTypes { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
