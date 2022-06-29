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

    public string Name { get; set; }

    public string? Description { get; set; }

    public Guid? ParentOrganisationId { get; set; }
}
