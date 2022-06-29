using LAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ServiceOptionCategoryConfiguration : IEntityTypeConfiguration<ServiceOptionCategory>
{
    public void Configure(EntityTypeBuilder<ServiceOptionCategory> builder)
    {
        builder.Property(t => t.ServiceOptionTypeId)
            .IsRequired();
        builder.Property(t => t.LinkId)
            .IsRequired();
        builder.Property(t => t.CategoryId)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}
