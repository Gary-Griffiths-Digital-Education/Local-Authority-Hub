using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class EligibilityConfiguration : IEntityTypeConfiguration<EligibilityDto>
{
    public void Configure(EntityTypeBuilder<EligibilityDto> builder)
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