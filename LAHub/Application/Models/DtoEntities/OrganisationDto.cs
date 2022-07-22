namespace Application.Models.DtoEntities;

public class OrganisationDto
{
    public OrganisationDto() { }

    public Guid Id { get; set; }
    public TenantDto Tenant { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public string? Description { get; set; } = default!;

    public string? LogoUrl { get; set; } = default!;
    public string? LogoAltText { get; set; } = default!;
    public ContactDto? Contact { get; set; } = default!;
    public ICollection<ServiceDto> Services { get; set; } = default!;
    public OrganisationTypeDto OrganisationType { get; set; } = default!;
}

/*
public class OrganisationDto
{
    public OrganisationDto() { }
    public Guid Id { get; set; }
    public TenantDto Tenant { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public string? Description { get; set; } = default!;

    public string? LogoUrl { get; set; } = default!;
    public string? LogoAltText { get; set; } = default!;
    public OrganisationTypeDto OrganisationType { get; set; } = default!;
    public ContactDto? Contact { get; set; } = default!;

    public ICollection<ServiceDto> Services { get; set; } = default!;
}
*/
/*
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
    }

    public Guid Id { get; set; }

    public TenantDto Tenant { get; set; } = default!;

    public OrganisationTypeDto OrganisationType { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string? Description { get; set; } = default!;

    public string? LogoUrl { get; set; } = default!;
    public string? LogoAltText { get; set; } = default!;

    public ContactDto? Contact { get; set; } = default!;

    public  ICollection<ServiceDto> Services { get; set; } = default!;
}
*/

