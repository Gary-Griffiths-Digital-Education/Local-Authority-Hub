namespace LAHub.Domain.Entities;

public class Eligibility : BaseAuditableEntity<Guid>
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

    public Guid? ServiceId { get; set; }

    public byte? MinimumAge { get; set; }

    public byte? MaximumAge { get; set; }
}

