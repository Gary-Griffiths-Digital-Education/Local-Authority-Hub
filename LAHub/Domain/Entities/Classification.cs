namespace LAHub.Domain.Entities;

public class Classification : BaseAuditableEntity<Guid>
{
    private Classification()
    {
        Name = string.Empty;
    }
    public Classification(
        string name,
        string? description
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
    }

    public string Name { get; private set; }

    public string? Description { get; private set; }
}
