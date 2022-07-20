using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;


namespace LAHub.Domain.Entities;

public class Location : BaseAuditableEntity<Guid>
{
    private Location()
    {
        Name = string.Empty;
    }
    public Location(
        string name,
        string? description,
        double latitude,
        double longitude,
        Address? address
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

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public double Latitude { get; private set; }

    public double Longitude { get; private set; }

    public Guid AddressId { get; set;  }
    public Address? Address { get; set; }
}

