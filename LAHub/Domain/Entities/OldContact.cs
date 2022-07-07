namespace LAHub.Domain.Entities;

public class OldContact : BaseAuditableEntity<Guid>
{
    public OldContact() 
    {
        Name = string.Empty;
    }
    public OldContact(
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
    public ContactMechanismType ContactMechanismType { get; set; } = default!;

    public Guid ServiceId { get; set; }
    public Service Service { get; set; } = default!;

    public string Name { get; set; }

    public string? Title { get; set; }
}
