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

    public Tenant Tenant { get; set; } = default!;

    public OrganisationType OrganisationType { get; set; } = default!;

    public string Name { get; set; } = String.Empty;

    public string? Description { get; set; } = String.Empty;

    public string? LogoUrl { get; set; } = default!;
    public string? LogoAltText { get; set; } = default!;

    public Guid? ContactId { get; set; } = default!;

    public virtual Contact? Contact { get; set; } = default!;


    public virtual ICollection<Service> Services { get; set; } = default!;
}
