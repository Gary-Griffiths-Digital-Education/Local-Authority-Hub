namespace Application.Models.DtoEntities;

public class LocationDto
{
    public LocationDto()
    {
        Name = string.Empty;
    }
    public LocationDto(
        string name,
        string? description,
        double latitude,
        double longitude,
        AddressDto? address
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
        Latitude = latitude;
        Longitude = longitude;
        Address = address;
        if (address != null)
            AddressId = address.Id;

    }

    public Guid Id { get; set; }
    public string Name { get; set; }

    public string? Description { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public Guid AddressId { get; set;  }
    public AddressDto? Address { get; set; }
}

