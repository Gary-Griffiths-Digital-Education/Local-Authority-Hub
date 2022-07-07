namespace LAHub.Domain.Entities;

public class Address : BaseAuditableEntity<Guid>
{
    public Address() 
    {
        AddressLine1 = default!;
        Postcode = default!;
    }
    public Address(
        string addressLine1,
        string? addressLine2,
        string? townOrCity,
        string postcode,
        Guid locationId,
        Location? location
    )
    {
        Id = Guid.NewGuid();
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2 ?? string.Empty;
        TownOrCity = townOrCity;
        Postcode = postcode;
        LocationId = locationId;
        Location = location;

    }

    public string AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? TownOrCity { get; set; }

    public string Postcode { get; set; }
    public Guid LocationId { get; set; }

    public virtual Location? Location { get; set; } = default!;
}


