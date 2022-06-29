using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<LocationDto>
{
    public void Configure(EntityTypeBuilder<LocationDto> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Description)
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(t => t.Latitude)
            .IsRequired();
        builder.Property(t => t.Longitude)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}