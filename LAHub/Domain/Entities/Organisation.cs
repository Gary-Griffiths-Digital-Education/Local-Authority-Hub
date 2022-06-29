namespace LAHub.Domain.Entities;

public class Organisation : BaseAuditableEntity<Guid>
{
    public Organisation()
    {
        Name = string.Empty;
    }

    public Organisation(
        string name,
        string? description,
        Guid? parentOrganisationId,
        Organisation? parentOrganisation
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
        ParentOrganisationId = parentOrganisationId ?? Guid.Empty;
        ParentOrganisation = parentOrganisation;
    }

    public string Name { get; set; }

    public string? Description { get; set; }

    public Guid? ParentOrganisationId { get; set; }
    public virtual Organisation? ParentOrganisation { get; set; } = default!;
    public virtual ICollection<Service> Services { get; set; } = default!;
}
