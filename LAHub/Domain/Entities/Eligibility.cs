using LAHub.Domain.Common;

namespace LAHub.Domain.Entities;

public class Eligibility : BaseEntity
{
    public Eligibility(
        Guid? serviceId,
        byte? minimumAge,
        byte? maximumAge
    )
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId ?? Guid.Empty;
        MinimumAge = minimumAge;
        MaximumAge = maximumAge;
    }

    public Guid? ServiceId { get; }

    public byte? MinimumAge { get; }

    public byte? MaximumAge { get; }
}

