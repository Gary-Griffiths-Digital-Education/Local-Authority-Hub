namespace LAHub.Domain.Entities;

public class Contact : BaseAuditableEntity<Guid>
{
    public Contact(
        Guid contactMechanismTypeId,
        Guid serviceId,
        string name,
        string? title
    )
    {
        Id = Guid.NewGuid();
        ContactMechanismTypeId = contactMechanismTypeId;
        ServiceId = serviceId;
        Name = name;
        Title = title ?? string.Empty;
    }

    public Guid ContactMechanismTypeId { get; set; }

    public Guid ServiceId { get; set; }

    public string Name { get; set; }

    public string? Title { get; set; }
}
