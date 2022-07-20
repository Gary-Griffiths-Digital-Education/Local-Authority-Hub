namespace LAHub.Domain.Entities;

public class ServiceCategory : BaseAuditableEntity<Guid>
{
    private ServiceCategory()
    {
    }

    public ServiceCategory(
        Service service,
        Category category
    )
    {
        Id = Guid.NewGuid();
        Category = category;
        Service  = service;
        ServiceId = service.Id;
        CategoryId = category.Id;
    }

    public Guid ServiceId { get; private set; }
    public Guid CategoryId { get; private set; }
    public virtual Service Service { get; private set; } = default!;
    public virtual Category Category { get; private set; } = default!;
}
