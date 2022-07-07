using LAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(t => t.AddressLine1)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.AddressLine2)
            .HasMaxLength(50);
        builder.Property(t => t.TownOrCity)
            .HasMaxLength(50);
        builder.Property(t => t.Postcode)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}
