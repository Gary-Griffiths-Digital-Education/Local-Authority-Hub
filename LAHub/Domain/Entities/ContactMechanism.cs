namespace LAHub.Domain.Entities;

public class ContactMechanism : BaseAuditableEntity<Guid>
{
    public ContactMechanism(
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
