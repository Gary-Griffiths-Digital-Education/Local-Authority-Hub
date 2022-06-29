using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ContactMechanismConfiguration : IEntityTypeConfiguration<ContactMechanismDto>
{
    public void Configure(EntityTypeBuilder<ContactMechanismDto> builder)
    {
        builder.Property(t => t.Name)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .IsRequired();
    }
}