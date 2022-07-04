using LAHub.Domain.Common;

namespace LAHub.Domain.Entities;

public class Contact : BaseEntity
{
    public Contact(
        Guid contactMechanismTypeId,
        Guid serviceId,
        string name,
        string? jobTitle
    )
    {
        Id = Guid.NewGuid();
        ContactMechanismTypeId = contactMechanismTypeId;
        ServiceId = serviceId;
        Name = name;
        JobTitle = jobTitle ?? string.Empty;
    }

    public Guid ContactMechanismTypeId { get; }

    public Guid ServiceId { get; }

    public string Name { get; }

    public string? Description { get; }

    public string? JobTitle { get; }
}
