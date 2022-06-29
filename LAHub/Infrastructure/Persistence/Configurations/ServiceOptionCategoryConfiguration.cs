using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ServiceOptionCategoryConfiguration : IEntityTypeConfiguration<ServiceOptionCategoryDto>
{
    public void Configure(EntityTypeBuilder<ServiceOptionCategoryDto> builder)
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
            .IsRequired();
    }
}
