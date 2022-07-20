namespace LAHub.Domain.Entities;

public class Organisation : BaseAuditableEntity<Guid>
{
    private Organisation() {}

    public Organisation(
        Tenant tenant,
        OrganisationType organisationType,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        Contact? contact
    )
    {
        Id = Guid.NewGuid();
        Tenant = tenant;
        OrganisationType = organisationType;
        Name = name;
        Description = description;
        LogoUrl = logoUrl;
        LogoAltText = logoAltText;
        Contact = contact;
        if (contact != null)
        {
            ContactId = contact.Id;
        }
    }

    public Tenant Tenant { get; private set; } = default!;

    public OrganisationType OrganisationType { get; private set; } = default!;

    public string Name { get; private set; } = String.Empty;

    public string? Description { get; private set; } = String.Empty;

    public string? LogoUrl { get; private set; } = default!;
    public string? LogoAltText { get; private set; } = default!;

    public Guid? ContactId { get; private set; } = default!;

    public virtual Contact? Contact { get; private set; } = default!;


    public virtual ICollection<Service> Services { get; set; } = default!;
}
