namespace LAHub.Domain.Entities;

public class Category : BaseAuditableEntity<Guid>
{
    public Category() { }

    public Category(
        string name,
        string? description = default,
        Category? parentCategory = default
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public string Name { get; set; }

    public string? Description { get; set; } = string.Empty;

    public Category? parentCategory { get; set; } = default;
}
