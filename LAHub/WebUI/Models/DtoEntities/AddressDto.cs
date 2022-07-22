namespace WebUI.Models.DtoEntities;

public class AddressDto
{
    public AddressDto() 
    {
        AddressLine1 = default!;
        Postcode = default!;
    }
    public AddressDto(
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

    public Guid Id { get; set; }
    public string AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? TownOrCity { get; set; }
     
    public string Postcode { get; }
    
}


