namespace LAHub.Domain.Entities;

public class Address : BaseAuditableEntity<Guid>
{
    public Address(
        string addressLine1,
        string? addressLine2,
        string? townOrCity,
        string postcode
    )
    {
        Id = Guid.NewGuid();
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2 ?? string.Empty;
        TownOrCity = townOrCity;
        Postcode = postcode;
    }

    public string AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? TownOrCity { get; set; }

    public string Postcode { get; set; }
}


