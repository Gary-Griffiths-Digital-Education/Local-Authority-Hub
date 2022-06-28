namespace LAHub.Domain.Entities;

public class ContactMechanismType : BaseAuditableEntity<Guid>
{
    public ContactMechanismType(
        string name,
        string? description
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
    }

    public string Name { get; }

    public string? Description { get; }
}
