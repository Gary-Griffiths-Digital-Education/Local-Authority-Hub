namespace LAHub.Domain.Entities;

public class ServiceLocation : BaseAuditableEntity<Guid>
{
    private ServiceLocation() { }

    public ServiceLocation(
        Guid serviceId,
        Guid locationId
    )
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId;
        LocationId = locationId;
    }

    public Guid ServiceId { get; private set; }
    public Guid LocationId { get; private set; }
    public virtual Service Service { get; set; } = default!;
    public virtual Location Location { get; set; } = default!;
}

