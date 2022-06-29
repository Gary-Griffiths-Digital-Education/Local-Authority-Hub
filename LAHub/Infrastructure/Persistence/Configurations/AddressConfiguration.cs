using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<AddressDto>
{
    public void Configure(EntityTypeBuilder<AddressDto> builder)
    {
        builder.Property(t => t.AddressLine1)
            .IsRequired();
        builder.Property(t => t.Postcode)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .IsRequired();
    }
}
