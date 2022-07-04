using LAHub.Domain.Common;

namespace LAHub.Domain.Entities;

public class ServiceArea : BaseEntity
{
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

    public Guid? ServiceId { get; }

    public string? Extent { get; }

    public string? Uri { get; }
}

