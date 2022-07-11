namespace LAHub.Domain.Entities;

public class Organisation : BaseAuditableEntity<Guid>
{
    public Organisation() {}

    public Organisation
    (
        Tenant tenant,
        OrganisationType organisationType,
        string name,
        string? description = default!,
        ICollection<Contact>? organisationContacts = default,
        ICollection<Service>? organisationServices = default,
        Organisation? parentOrganisation = default
    )
    {
        Id = Guid.NewGuid();
        Tenant = tenant;
        OrganisationType = organisationType;
        Name = name;
        Description = description;
        OrganisationContacts = organisationContacts;
        OrganisationServices = organisationServices;
        ParentOrganisation = parentOrganisation;
    }

    public Tenant Tenant { get; set; } = default!;

    public OrganisationType OrganisationType { get; set; } = default!;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    public virtual Organisation? ParentOrganisation { get; set; } = default;

    public Guid ParentOrganisationId { get; set; } = Guid.Empty;

    public virtual ICollection<Contact>? OrganisationContacts { get; set; } = default;

    public virtual ICollection<Service>? OrganisationServices { get; set; } = default;
}
