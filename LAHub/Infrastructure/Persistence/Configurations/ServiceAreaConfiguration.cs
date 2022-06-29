using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ServiceAreaConfiguration : IEntityTypeConfiguration<ServiceAreaDto>
{
    public void Configure(EntityTypeBuilder<ServiceAreaDto> builder)
    {
        builder.Property(t => t.ServiceId)
            .IsRequired();
        builder.Property(t => t.Extent)
            .HasMaxLength(255);
        builder.Property(t => t.Uri)
            .HasMaxLength(255);
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}