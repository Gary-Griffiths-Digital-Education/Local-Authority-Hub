namespace LAHub.Domain.Entities;

public class Address : BaseAuditableEntity<Guid>
{
    private Address() 
    {
        AddressLine1 = default!;
        Postcode = default!;
    }
    public Address(
        string addressLine1,
        string? addressLine2,
        string? townOrCity,
        string postcode
        //Location? location
    )
    {
        Id = Guid.NewGuid();
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2 ?? string.Empty;
        TownOrCity = townOrCity;
        Postcode = postcode;
        //Location = location;
        //if (location != null)
        //    LocationId = location.Id;

    }

    public string AddressLine1 { get; private set; }

    public string? AddressLine2 { get; private set; }

    public string? TownOrCity { get; private set; }
     
    public string Postcode { get; }
    //public Guid LocationId { get; set; }

    //public virtual Location? Location { get; set; } = default!;
}


