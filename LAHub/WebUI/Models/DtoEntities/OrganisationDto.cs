namespace WebUI.Models.DtoEntities;

public class OrganisationDto
{
    public OrganisationDto() { }

    public OrganisationDto(
        TenantDto tenant,
        OrganisationTypeDto organisationType,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        ContactDto? contact
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

    public Guid Id { get; set; }

    public TenantDto Tenant { get; set; } = default!;

    public OrganisationTypeDto OrganisationType { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string? Description { get; set; } = default!;

    public string? LogoUrl { get; set; } = default!;
    public string? LogoAltText { get; set; } = default!;

    public Guid? ContactId { get; set; } = default!;

    public virtual ContactDto? Contact { get; set; } = default!;

    public virtual ICollection<ServiceDto> Services { get; set; } = default!;
}


