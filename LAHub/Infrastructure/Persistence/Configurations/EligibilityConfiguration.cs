using LAHub.Domain.OpenReferralEnities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class EligibilityConfiguration : IEntityTypeConfiguration<OpenReferralEligibility>
{
    public void Configure(EntityTypeBuilder<OpenReferralEligibility> builder)
    {
        builder.Property(t => t.Eligibility)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}
