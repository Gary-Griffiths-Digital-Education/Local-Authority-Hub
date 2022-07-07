using LAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class OperatingHoursConfiguration : IEntityTypeConfiguration<OperatingHours>
{
    public void Configure(EntityTypeBuilder<OperatingHours> builder)
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