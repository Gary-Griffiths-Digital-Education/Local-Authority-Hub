namespace LAHub.Domain.Entities;

public class ServiceOptionCategory : BaseAuditableEntity<Guid>
{
    public ServiceOptionCategory(
        Guid serviceOptionTypeId,
        Guid linkId,
        Guid categoryId
    )
    {
        Id = Guid.NewGuid();
        ServiceOptionTypeId = serviceOptionTypeId;
        LinkId = linkId;
        CategoryId = categoryId;
    }

    public Guid ServiceOptionTypeId { get; set; }

    public Guid LinkId { get; set; }

    public Guid CategoryId { get; }
}

