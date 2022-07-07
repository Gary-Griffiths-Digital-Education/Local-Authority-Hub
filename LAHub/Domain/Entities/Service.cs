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
        Organisation? organisation
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
        Organisation = organisation;
    }

    public string Name { get; set; }

    public string? Description { get; set; }

    public virtual Organisation? Organisation { get; set; } = default!;

    public ICollection<ServiceLocation> ServiceLocations { get; set; } = default!;
}
