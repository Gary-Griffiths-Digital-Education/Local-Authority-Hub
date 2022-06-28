namespace LAHub.Domain.Entities;

public class Organisation : BaseAuditableEntity<Guid>
{
    public Organisation(
        string name,
        string? description,
        Guid? parentOrganisationId
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
        ParentOrganisationId = parentOrganisationId ?? Guid.Empty;
    }

    public string Name { get; }

    public string? Description { get; }

    public Guid? ParentOrganisationId { get; }
}
