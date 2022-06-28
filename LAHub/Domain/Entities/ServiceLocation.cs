namespace LAHub.Domain.Entities;

public class ServiceLocation : BaseAuditableEntity<Guid>
{
    public ServiceLocation(
        Guid serviceId,
        Guid locationId
    )
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId;
        LocationId = locationId;
    }

    public Guid ServiceId { get; }

    public Guid LocationId { get; }
}

