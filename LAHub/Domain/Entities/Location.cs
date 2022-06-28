namespace LAHub.Domain.Entities;

public class Location : BaseAuditableEntity<Guid>
{
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

    public string Name { get; }

    public string? Description { get; }

    public double Latitude { get; }

    public double Longitude { get; }
}

