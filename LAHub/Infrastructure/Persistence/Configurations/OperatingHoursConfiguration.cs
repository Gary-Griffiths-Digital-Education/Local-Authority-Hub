using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class OperatingHoursConfiguration : IEntityTypeConfiguration<OperatingHoursDto>
{
    public void Configure(EntityTypeBuilder<OperatingHoursDto> builder)
    {
        builder.Property(t => t.ServiceId)
            .IsRequired();
        builder.Property(t => t.ServiceLocationId)
            .IsRequired();
        builder.Property(t => t.Description)
            .HasMaxLength(500);
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}