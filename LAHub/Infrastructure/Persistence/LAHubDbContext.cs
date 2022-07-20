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
    public DbSet<Classification> Classifications => Set<Classification>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Organisation> Organisations => Set<Organisation>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Tenant> Tenants => Set<Tenant>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.Entity<LAHub.Domain.Entities.Location>()
        //    .Property(e => e.LocationPoint)
        //    .HasColumnType("geography (point)");

        //builder.Entity<LAHub.Domain.Entities.Classification>()
        //    .HasOne<Grade>(s => s.Grade)
        //    .WithMany(g => g.Students)
        //    .HasForeignKey(s => s.CurrentGradeId);

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
