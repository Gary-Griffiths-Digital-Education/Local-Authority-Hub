using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<ContactDto>
{
    public void Configure(EntityTypeBuilder<ContactDto> builder)
    {
        builder.Property(t => t.ContactMechanismTypeId)
            .IsRequired();
        builder.Property(t => t.ServiceId)
            .IsRequired();
        builder.Property(t => t.Name)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .IsRequired();
    }
}