namespace LAHub.Domain.Entities;

public class ServiceArea : BaseAuditableEntity<Guid>
{
    private ServiceArea()
    {
    }

    public ServiceArea(
        Guid? serviceId,
        string? extent,
        string? uri
    )
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId ?? Guid.Empty;
        Extent = extent ?? default!;
        Uri = uri ?? default!;
    }

    public Guid? ServiceId { get; private set; }

    public string? Extent { get; private set; }

    public string? Uri { get; private set; }
}

