using Application.Common.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Infrastructure.Common;
using Infrastructure.Identity;
using Infrastructure.Persistence.Interceptors;
using LAHub.Domain.Entities;
using LAHub.Domain.OpenReferralEnities;
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
    public DbSet<Classification> Classifications => Set<Classification>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Organisation> Organisations => Set<Organisation>();
    public DbSet<OrganisationType> OrganisationTypes => Set<OrganisationType>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Tenant> Tenants => Set<Tenant>();

    #region Open Referral Entities
    public DbSet<Accessibility_For_Disabilities> Accessibility_For_Disabilities => Set<Accessibility_For_Disabilities>();
    public DbSet<OpenReferralContact> OpenReferralContacts => Set<OpenReferralContact>();
    public DbSet<OpenReferralCost_Option> OpenReferralCost_Options => Set<OpenReferralCost_Option>();
    public DbSet<OpenReferralEligibility> OpenReferralEligibilities => Set<OpenReferralEligibility>();
    public DbSet<OpenReferralFunding> OpenReferralFundings => Set<OpenReferralFunding>();   
    public DbSet<OpenReferralHoliday_Schedule> OpenReferralHoliday_Schedules => Set<OpenReferralHoliday_Schedule>();
    public DbSet<OpenReferralLanguage> OpenReferralLanguages => Set<OpenReferralLanguage>();
    public DbSet<OpenReferralLinktaxonomycollection> OpenReferralLinktaxonomycollections => Set<OpenReferralLinktaxonomycollection>();
    public DbSet<OpenReferralLocation> OpenReferralLocations => Set<OpenReferralLocation>();
    public DbSet<OpenReferralOrganisation> OpenReferralOrganisations => Set<OpenReferralOrganisation>();
    public DbSet<OpenReferralParent> OpenReferralParents => Set<OpenReferralParent>();
    public DbSet<OpenReferralPhone> OpenReferralPhones => Set<OpenReferralPhone>();
    public DbSet<OpenReferralPhysical_Address> OpenReferralPhysical_Addresses => Set<OpenReferralPhysical_Address>();
    public DbSet<OpenReferralRegular_Schedule> OpenReferralRegular_Schedules => Set<OpenReferralRegular_Schedule>();
    public DbSet<OpenReferralReview> OpenReferralReviews => Set<OpenReferralReview>();
    public DbSet<OpenReferralService> OpenReferralServices => Set<OpenReferralService>();
    public DbSet<OpenReferralService_Area> OpenReferralService_Areas => Set<OpenReferralService_Area>();
    public DbSet<OpenReferralService_Taxonomy> OpenReferralService_Taxonomies => Set<OpenReferralService_Taxonomy>();
    public DbSet<OpenReferralServiceAtLocation> OpenReferralServiceAtLocations => Set<OpenReferralServiceAtLocation>();
    public DbSet<OpenReferralTaxonomy> OpenReferralTaxonomies => Set<OpenReferralTaxonomy>();
    public DbSet<OpenReferralServiceDelivery> OpenReferralServiceDeliveries => Set<OpenReferralServiceDelivery>();
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.Entity<LAHub.Domain.Entities.Location>()
        //    .Property(e => e.LocationPoint)
        //    .HasColumnType("geography (point)");

        //builder.Entity<LAHub.Domain.Entities.Classification>()
        //    .HasOne<Grade>(s => s.Grade)
        //    .WithMany(g => g.Students)
        //    .HasForeignKey(s => s.CurrentGradeId);

        builder.Entity<OpenReferralServiceDelivery>().HasEnum(e => e.ServiceDelivery);

        builder.Entity<LAHub.Domain.Entities.Service>()
            .HasMany(x => x.ServiceClassifications);

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
