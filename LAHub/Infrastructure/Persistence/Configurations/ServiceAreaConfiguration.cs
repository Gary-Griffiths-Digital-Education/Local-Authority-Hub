using LAHub.Domain.OpenReferralEnities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ServiceAreaConfiguration : IEntityTypeConfiguration<OpenReferralService_Area>
{
    public void Configure(EntityTypeBuilder<OpenReferralService_Area> builder)
    {
        builder.Property(t => t.Service_area)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}
