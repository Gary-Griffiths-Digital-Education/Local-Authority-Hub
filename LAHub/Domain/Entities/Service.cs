namespace LAHub.Domain.Entities;

public class Service : BaseAuditableEntity<Guid>
{
    private Service()
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

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public virtual Organisation? Organisation { get; private set; } = default!;

    public ICollection<ServiceLocation> ServiceLocations { get; set; } = default!;
}
