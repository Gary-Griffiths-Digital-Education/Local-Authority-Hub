namespace LAHub.Domain.Entities;

public class Service : BaseAuditableEntity<Guid>
{
    public Service() { }

    public Service
    (
        Tenant tenant,
        string name,
        string? description = default,
        Category? serviceCategory = default,
        ICollection<Contact>?  serviceContacts = default,
        Organisation? organisation = default
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Organisation = organisation;
        ServiceCategory = serviceCategory;
        ServiceContacts = serviceContacts;
    }

    public string Name { get; set; } = String.Empty;

    public string? Description { get; set; } = String.Empty;

    public virtual Category? ServiceCategory { get; set; } = default;

    public virtual ICollection<Contact>? ServiceContacts { get; set; } = default;

    public virtual Organisation? Organisation { get; set; } = default;
}
