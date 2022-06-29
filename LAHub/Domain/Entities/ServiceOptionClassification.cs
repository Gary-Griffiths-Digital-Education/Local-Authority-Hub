namespace LAHub.Domain.Entities;

public class ServiceOptionClassification : BaseAuditableEntity<Guid>
{
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

    public Guid ServiceOptionTypeId { get; set; }

    public Guid LinkId { get; set; }

    public Guid ClassificationId { get; set; }
}

