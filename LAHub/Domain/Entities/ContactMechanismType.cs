namespace LAHub.Domain.Entities;

public class ContactMechanismType : BaseAuditableEntity<Guid>
{
    public ContactMechanismType()
    {
        Name = String.Empty;
    }
    public ContactMechanismType(
        string name,
        string? description
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
    }

    public string Name { get; set; }

    public string? Description { get; set; }
}
