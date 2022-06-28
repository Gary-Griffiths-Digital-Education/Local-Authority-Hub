namespace LAHub.Domain.Entities;

public class ServiceClassification : BaseAuditableEntity<Guid>
{
    public ServiceClassification(
        Guid serviceId,
        Guid classificationId
    )
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId;
        ClassificationId = classificationId;
    }

    public Guid ServiceId { get; }

    public Guid ClassificationId { get; }
}
