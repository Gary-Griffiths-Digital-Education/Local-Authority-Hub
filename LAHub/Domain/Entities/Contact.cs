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

    public Guid ContactMechanismTypeId { get; }

    public Guid ServiceId { get; }

    public string Name { get; }

    public string? Title { get; }
}
