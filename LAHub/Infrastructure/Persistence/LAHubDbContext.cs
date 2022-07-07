using Application.Common.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Infrastructure.Identity;
using Infrastructure.Persistence.Interceptors;
using LAHub.Domain.Entities;
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

    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Classification> Classifications => Set<Classification>();
    public DbSet<OldContact> Contacts => Set<OldContact>();
    public DbSet<ContactMechanism> ContactMechanisms => Set<ContactMechanism>();
    public DbSet<ContactMechanismType> ContactMechanismTypes => Set<ContactMechanismType>();
    public DbSet<Eligibility> Eligibilities => Set<Eligibility>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<OperatingHours> OperatingHours => Set<OperatingHours>();
    public DbSet<Organisation> Organisations => Set<Organisation>();
    public DbSet<ServiceArea> ServiceAreas => Set<ServiceArea>();
    public DbSet<ServiceCategory> ServiceCategories => Set<ServiceCategory>();
    public DbSet<ServiceClassification> ServiceClassifications => Set<ServiceClassification>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<ServiceLocation> ServiceLocations => Set<ServiceLocation>();
    public DbSet<ServiceOptionCategory> ServiceOptionCategories => Set<ServiceOptionCategory>();
    public DbSet<ServiceOptionClassification> ServiceOptionClassifications => Set<ServiceOptionClassification>();
    public DbSet<ServiceOptionType> ServiceOptionTypes => Set<ServiceOptionType>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }

}
