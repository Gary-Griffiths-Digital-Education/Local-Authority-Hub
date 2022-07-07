namespace LAHub.Domain.Entities;

public class Classification : BaseAuditableEntity<Guid>
{
    public Classification()
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

    public string Name { get; set; }

    public string? Description { get; set; }
}
