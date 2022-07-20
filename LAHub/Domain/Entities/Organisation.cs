namespace LAHub.Domain.Entities;

public class Organisation : BaseAuditableEntity<Guid>
{
    private Organisation() {}

    public Organisation(
        Tenant tenant,
        OrganisationType organisationType,
        string name,
        string? description,
        Organisation? parentOrganisation,
        Guid parentOrganisationId
    )
    {
        Id = Guid.NewGuid();
        Tenant = tenant;
        OrganisationType = organisationType;
        Name = name;
        Description = description;
        ParentOrganisation = parentOrganisation;
        ParentOrganisationId = parentOrganisationId;
    }

    public Tenant Tenant { get; private set; } = default!;

    public OrganisationType OrganisationType { get; private set; } = default!;

    public string Name { get; private set; } = String.Empty;

    public string? Description { get; private set; } = String.Empty;

    public virtual Organisation? ParentOrganisation { get; private set; } = default!;

    public Guid ParentOrganisationId { get; private set; } = Guid.Empty;

    public virtual ICollection<Contact> OrganisationContacts { get; set; } = default!;

    public virtual ICollection<Service> Services { get; set; } = default!;
}
