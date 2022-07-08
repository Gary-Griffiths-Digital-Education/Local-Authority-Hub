namespace LAHub.Domain.Entities;

public class ServiceCategory : BaseAuditableEntity<Guid>
{
    public ServiceCategory()
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

    public Guid ServiceId { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Service Service { get; set; } = default!;
    public virtual Category Category { get; set; } = default!;
}
