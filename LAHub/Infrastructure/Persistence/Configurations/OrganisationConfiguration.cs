using LAHub.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class OrganisationConfiguration : IEntityTypeConfiguration<OrganisationDto>
{
    public void Configure(EntityTypeBuilder<OrganisationDto> builder)
    {
        builder.Property(t => t.Name)
            .IsRequired();
        builder.Property(t => t.Created)
            .IsRequired();
        builder.Property(t => t.CreatedBy)
            .IsRequired();
    }
}