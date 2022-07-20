namespace LAHub.Domain.Entities;

public class Category : BaseAuditableEntity<Guid>
{
    private Category() 
    {
        Name = string.Empty;
    }
    public Category(
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
