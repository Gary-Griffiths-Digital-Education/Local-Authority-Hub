namespace LAHub.Domain.Entities;

public class ServiceOptionCategory : BaseAuditableEntity<Guid>
{
    public ServiceOptionCategory(
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

    public Guid ServiceOptionTypeId { get; }

    public Guid LinkId { get; }

    public Guid ClassificationId { get; }
}

