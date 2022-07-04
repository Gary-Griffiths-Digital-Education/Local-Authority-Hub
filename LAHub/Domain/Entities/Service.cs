using LAHub.Domain.Common;

namespace LAHub.Domain.Entities;

public class Service : BaseEntity
{
    public Service(
        string name,
        string? description,
        Guid organisationId
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
        OrganisationId = organisationId;
    }

    public string Name { get; }

    public string? Description { get; }

    public Guid OrganisationId { get; }
}
