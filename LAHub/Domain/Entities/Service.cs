﻿namespace LAHub.Domain.Entities;

public class Service : BaseAuditableEntity<Guid>
{
    public Service()
    {
        Name = String.Empty;
    }
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

    public string Name { get; set; }

    public string? Description { get; set; }

    public Guid OrganisationId { get; set; }

    public ICollection<ServiceLocation> ServiceLocations { get; set; } = default!;
}
