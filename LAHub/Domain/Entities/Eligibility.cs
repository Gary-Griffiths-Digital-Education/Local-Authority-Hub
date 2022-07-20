namespace LAHub.Domain.Entities;

public class Eligibility : BaseAuditableEntity<Guid>
{
    private Eligibility()
    {
    }
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

    public Guid? ServiceId { get; private set; }

    public byte? MinimumAge { get; private set; }

    public byte? MaximumAge { get; private set; }
}

