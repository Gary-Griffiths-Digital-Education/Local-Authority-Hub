namespace LAHub.Domain.Entities;

public class ServiceCategory : BaseAuditableEntity<Guid>
{
    public ServiceCategory(
        Guid serviceId,
        Guid categoryId
    )
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId;
        CategoryId = categoryId;
    }

    public Guid ServiceId { get; }

    public Guid CategoryId { get; }
}
