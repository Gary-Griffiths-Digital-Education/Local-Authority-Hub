namespace LAHub.Domain.Entities;

public class Service : BaseAuditableEntity<Guid>
{
    public Service()
    {
        Name = String.Empty;
    }
    public Service(
        string name,
        string? description,
        Guid organisationId,
        Organisation? organisation
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
        OrganisationId = organisationId;
        Organisation = organisation;
    }

    public string Name { get; set; }

    public string? Description { get; set; }

    public Guid OrganisationId { get; set; }
    public virtual Organisation? Organisation { get; set; } = default!;
    public ICollection<ServiceLocation> ServiceLocations { get; set; } = default!;
}
