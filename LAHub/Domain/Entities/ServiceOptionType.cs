using LAHub.Domain.Common;

namespace LAHub.Domain.Entities;

public class ServiceOptionType : BaseEntity
{
    public ServiceOptionType(
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

