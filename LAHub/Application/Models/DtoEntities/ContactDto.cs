namespace Application.Models.DtoEntities;

public class ContactDto
{
    public ContactDto() { }

    
    public ContactDto(
        TenantDto tenant,
        string name,
        string? description,
        string? telephone,
        string? nextGenerationText,
        string? whatsApp,
        string? email,
        Uri? webSite,
        Uri? faceBook,
        Uri? twitter,
        Uri? forum,
        string? addressLine1,
        string? addressLine2,
        string? townOrCity,
        string? county,
        string? postcode,
        string? minicom
    )
    {
        Id = Guid.NewGuid();
        Tenant = tenant;
        Name = name;
        Description = description;
        Telephone = telephone;
        NextGenerationText = nextGenerationText;
        WhatsApp = whatsApp;
        Email = email;
        WebSite = webSite;
        FaceBook = faceBook;
        Twitter = twitter;
        Forum = forum;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        TownOrCity = townOrCity;
        County = county;
        Postcode = postcode;
        Minicom = minicom;
    }

    public Guid Id { get; set; }

    public TenantDto Tenant { get; set; } = default!;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    public string? Telephone { get; set; } = string.Empty;

    public string? NextGenerationText { get; set; } = string.Empty;

    public string? Minicom { get; set; } = string.Empty;

    public string? WhatsApp { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    public Uri? WebSite { get; set; } = default!;

    public Uri? FaceBook { get; set; } = default!;

    public Uri? Twitter { get; set; } = default!;

    public Uri? Forum { get; set; } = default!;

    public string? AddressLine1 { get; set; } = string.Empty;

    public string? AddressLine2 { get; set; } = string.Empty;

    public string? TownOrCity { get; set; } = string.Empty;

    public string? County { get; set; } = string.Empty;

    public string? Postcode { get; set; }
    public string? Title { get; set; }

}
