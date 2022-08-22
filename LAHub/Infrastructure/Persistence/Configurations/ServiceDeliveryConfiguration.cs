using LAHub.Domain.OpenReferralEnities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ServiceDeliveryConfiguration : IEntityTypeConfiguration<OpenReferralServiceDeliveryEx>
{
    public void Configure(EntityTypeBuilder<OpenReferralServiceDeliveryEx> builder)
    {
        builder.Property(t => t.ServiceDeliveryEx)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}