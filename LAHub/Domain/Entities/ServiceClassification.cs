namespace LAHub.Domain.Entities;

public class ServiceClassification : BaseAuditableEntity<Guid>
{
    private ServiceClassification()
    {
    }

    public ServiceClassification(
        Guid serviceId,
        Guid classificationId
    )
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId;
        ClassificationId = classificationId;
    }

    public Guid ServiceId { get; private set; }

    public Guid ClassificationId { get; private set; }
}
