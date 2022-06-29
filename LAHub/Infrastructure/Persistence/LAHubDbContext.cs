using Application.Common.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Infrastructure.Identity;
using Infrastructure.Persistence.Interceptors;
using LAHub.Domain.DbEntities;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Infrastructure.Persistence;

public class LAHubDbContext : ApiAuthorizationDbContext<ApplicationUser>, ILAHubDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public LAHubDbContext(
        DbContextOptions<LAHubDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<AddressDto> Addresses => Set<AddressDto>();
    public DbSet<CategoryDto> Categories => Set<CategoryDto>();
    public DbSet<ClassificationDto> Classifications => Set<ClassificationDto>();
    public DbSet<ContactDto> Contacts => Set<ContactDto>();
    public DbSet<ContactMechanismDto> ContactMechanisms => Set<ContactMechanismDto>();
    public DbSet<ContactMechanismTypeDto> ContactMechanismTypes => Set<ContactMechanismTypeDto>();
    public DbSet<EligibilityDto> Eligibilities => Set<EligibilityDto>();
    public DbSet<LocationDto> Locations => Set<LocationDto>();
    public DbSet<OperatingHoursDto> OperatingHours => Set<OperatingHoursDto>();
    public DbSet<OrganisationDto> Organisations => Set<OrganisationDto>();
    public DbSet<ServiceAreaDto> ServiceAreas => Set<ServiceAreaDto>();
    public DbSet<ServiceCategoryDto> ServiceCategories => Set<ServiceCategoryDto>();
    public DbSet<ServiceClassificationDto> ServiceClassifications => Set<ServiceClassificationDto>();
    public DbSet<ServiceDto> Services => Set<ServiceDto>();
    public DbSet<ServiceLocationDto> ServiceLocations => Set<ServiceLocationDto>();
    public DbSet<ServiceOptionCategoryDto> ServiceOptionCategories => Set<ServiceOptionCategoryDto>();
    public DbSet<ServiceOptionClassificationDto> ServiceOptionClassifications => Set<ServiceOptionClassificationDto>();
    public DbSet<ServiceOptionTypeDto> ServiceOptionTypes => Set<ServiceOptionTypeDto>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }

}
