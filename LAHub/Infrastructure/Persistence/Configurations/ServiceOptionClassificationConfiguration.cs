using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ServiceOptionClassificationConfiguration : IEntityTypeConfiguration<ServiceOptionClassificationDto>
{
    public void Configure(EntityTypeBuilder<ServiceOptionClassificationDto> builder)
    {
        builder.Property(t => t.ServiceOptionTypeId)
            .IsRequired();
        builder.Property(t => t.LinkId)
            .IsRequired();
        builder.Property(t => t.ClassificationId)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .HasMaxLength(255)
            .IsRequired();
    }
}