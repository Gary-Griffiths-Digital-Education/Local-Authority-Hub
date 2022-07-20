namespace LAHub.Domain.Entities;

public class ServiceOptionCategory : BaseAuditableEntity<Guid>
{
    private ServiceOptionCategory() { }

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

    public Guid ServiceOptionTypeId { get; private set; }

    public Guid LinkId { get; private set; }

    public Guid CategoryId { get; private set; }
}

