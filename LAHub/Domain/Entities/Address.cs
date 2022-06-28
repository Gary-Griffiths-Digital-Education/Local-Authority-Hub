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

    public string AddressLine1 { get; }

    public string? AddressLine2 { get; }

    public string? TownOrCity { get; }

    public string Postcode { get; }
}


