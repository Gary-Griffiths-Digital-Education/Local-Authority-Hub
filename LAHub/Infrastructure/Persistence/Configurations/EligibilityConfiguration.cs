using LAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class EligibilityConfiguration : IEntityTypeConfiguration<Eligibility>
{
    public void Configure(EntityTypeBuilder<Eligibility> builder)
    {
        builder.Property(t => t.ServiceId)
            .IsRequired();
        builder.Property(t => t.MinimumAge)
            .IsRequired();
        builder.Property(t => t.MaximumAge)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .IsRequired();
    }
}