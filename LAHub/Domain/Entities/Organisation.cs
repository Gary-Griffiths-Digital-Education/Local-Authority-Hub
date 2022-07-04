using LAHub.Domain.Interfaces;

namespace LAHub.Domain.Entities;

public class Organisation : BaseEntity, IAggregateRoot
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public Organisation? ParentOrganisation { get; set; }

    public Organisation() { }

    public Organisation(
        string? name,
        string? description = default!,
        Organisation parentOrganisation = default!
    )
    {
        Id = Guid.NewGuid();
        Name = name ?? String.Empty;
        Description = description ?? String.Empty;
        ParentOrganisation = parentOrganisation;
    }
}
