﻿using LAHub.Domain.OpenReferralEnities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<OpenReferralPhysical_Address>
{
    public void Configure(EntityTypeBuilder<OpenReferralPhysical_Address> builder)
    {
        builder.Property(t => t.Address_1)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.City)
            .HasMaxLength(50);
        builder.Property(t => t.Postal_code)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}
