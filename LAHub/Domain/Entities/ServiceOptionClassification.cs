namespace LAHub.Domain.Entities;

public class ServiceOptionClassification : BaseAuditableEntity<Guid>
{
    private ServiceOptionClassification() { }

    public ServiceOptionClassification(
        Guid serviceOptionTypeId,
        Guid linkId,
        Guid classificationId
    )
    {
        Id = Guid.NewGuid();
        ServiceOptionTypeId = serviceOptionTypeId;
        LinkId = linkId;
        ClassificationId = classificationId;
    }

    public Guid ServiceOptionTypeId { get; private set; }

    public Guid LinkId { get; private set; }

    public Guid ClassificationId { get; private set; }
}

