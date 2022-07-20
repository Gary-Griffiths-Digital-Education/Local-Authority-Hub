namespace LAHub.Domain.Entities;

public class ServiceClassification : BaseAuditableEntity<Guid>
{
    private ServiceClassification()
    {
    }

    public ServiceClassification(
        Guid serviceId,
        Classification classification
    )
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId;
        Classification = classification;
        if (classification != null)
        {
            ClassificationId = classification.Id;
        }
    }

    public Guid ServiceId { get; private set; }

    public Guid ClassificationId { get; private set; }

    public Classification Classification { get; private set; } = default!;
}
