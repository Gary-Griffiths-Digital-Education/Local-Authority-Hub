namespace LAHub.Domain.Entities;

public class Contact : BaseAuditableEntity<Guid>
{
    public Contact() { }

    
    public Contact(
        Tenant tenant,
        string name,
        string? description = default,
        string? telephone = default,
        string? nextGenerationText = default,
        string? whatsApp = default,
        string? email = default,
        Uri? webSite = default,
        Uri? faceBook = default,
        Uri? twitter  = default,
        Uri? forum = default,
        string? addressLine1 = default,
        string? addressLine2 = default,
        string? townOrCity = default,
        string? county = default,
        string? postcode = default,
        string? minicom = default,
        double? latitude = default,
        double? longitude = default
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
        Latitude = latitude;
        Longitude = longitude;
    }
    
    public Tenant Tenant { get; set; } = default!;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    public string? Telephone { get; set; } = string.Empty;

    public string? NextGenerationText { get; set; } = string.Empty;

    public string? Minicom { get; set; } = string.Empty;

    public string? WhatsApp { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    public Uri? WebSite { get; set; } = default;

    public Uri? FaceBook { get; set; } = default;

    public Uri? Twitter { get; set; } = default;

    public Uri? Forum { get; set; } = default;

    public string? AddressLine1 { get; set; } = string.Empty;

    public string? AddressLine2 { get; set; } = string.Empty;

    public string? TownOrCity { get; set; } = string.Empty;

    public string? County { get; set; } = string.Empty;

    public string? Postcode { get; set; } = string.Empty;

    public double? Latitude { get; set; } = default;

    public double? Longitude { get; set; } = default;
}
