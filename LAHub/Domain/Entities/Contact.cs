namespace LAHub.Domain.Entities;

public class Contact : BaseAuditableEntity<Guid>
{
    private Contact() { }

    
    public Contact(
        Tenant? tenant,
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
    
    public Tenant? Tenant { get; private set; } = default!;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; private set; } = string.Empty;

    public string? Telephone { get; private set; } = string.Empty;

    public string? NextGenerationText { get; private set; } = string.Empty;

    public string? Minicom { get; private set; } = string.Empty;

    public string? WhatsApp { get; private set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    public Uri? WebSite { get; private set; } = default!;

    public Uri? FaceBook { get; private set; } = default!;

    public Uri? Twitter { get; private set; } = default!;

    public Uri? Forum { get; private set; } = default!;

    public string? AddressLine1 { get; private set; } = string.Empty;

    public string? AddressLine2 { get; private set; } = string.Empty;

    public string? TownOrCity { get; private set; } = string.Empty;

    public string? County { get; private set; } = string.Empty;

    public string? Postcode { get; private set; }
    public string? Title { get; set; }

}
