namespace LAHub.Domain.Entities;

public class Category : BaseAuditableEntity<Guid>
{
    public Category() 
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

    public string Name { get; set; }

    public string? Description { get; set; }
}
