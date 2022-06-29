using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryDto>
{
    public void Configure(EntityTypeBuilder<CategoryDto> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}

