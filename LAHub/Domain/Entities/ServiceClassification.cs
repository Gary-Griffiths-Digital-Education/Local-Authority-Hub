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

    public Guid ServiceId { get; set; }

    public Guid ClassificationId { get; set; }
}
