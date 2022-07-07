namespace LAHub.Domain.Entities;

public class Organisation : BaseAuditableEntity<Guid>
{
    public Organisation() {}

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

    public Tenant Tenant { get; set; } = default!;

    public OrganisationType OrganisationType { get; set; } = default!;

    public string Name { get; set; } = String.Empty;

    public string? Description { get; set; } = String.Empty;

    public virtual Organisation? ParentOrganisation { get; set; } = default!;

    public Guid ParentOrganisationId { get; set; } = Guid.Empty;

    //public virtual ICollection<Contact> OrganisationContacts { get; set; } = default!;

    //public virtual ICollection<Service> Services { get; set; } = default!;
}
