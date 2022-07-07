using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;


namespace LAHub.Domain.Entities;

public class Location : BaseAuditableEntity<Guid>
{
    public Location()
    {
        Name = string.Empty;
    }
    public Location(
        string name,
        string? description,
        double latitude,
        double longitude
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get; set; }

    public string? Description { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}

