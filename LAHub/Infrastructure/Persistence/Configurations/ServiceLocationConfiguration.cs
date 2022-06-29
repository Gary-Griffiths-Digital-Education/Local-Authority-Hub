using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ServiceLocationConfiguration : IEntityTypeConfiguration<ServiceLocationDto>
{
    public void Configure(EntityTypeBuilder<ServiceLocationDto> builder)
    {
        builder.Property(t => t.ServiceId)
            .IsRequired();
        builder.Property(t => t.LocationId)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .IsRequired();
    }
}