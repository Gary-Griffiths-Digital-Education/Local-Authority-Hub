namespace LAHub.Domain.Entities;

public class ServiceLocation : BaseAuditableEntity<Guid>
{
    public ServiceLocation() { }

    public ServiceLocation(
        Guid serviceId,
        Guid locationId
    )
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId;
        LocationId = locationId;
    }

    public Guid ServiceId { get; set; }
    public Guid LocationId { get; set; }
    public virtual Service Service { get; set; } = default!;
    public virtual Location Location { get; set; } = default!;
}

