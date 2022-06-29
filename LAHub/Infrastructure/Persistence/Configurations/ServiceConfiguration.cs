using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<ServiceDto>
{
    public void Configure(EntityTypeBuilder<ServiceDto> builder)
    {
        builder.Property(t => t.Name)
            .IsRequired();
        builder.Property(t => t.OrganisationId)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .IsRequired();
    }
}