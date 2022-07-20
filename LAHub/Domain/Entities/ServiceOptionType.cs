namespace LAHub.Domain.Entities;

public class ServiceOptionType : BaseAuditableEntity<Guid>
{
    private ServiceOptionType() 
    {
        Name = string.Empty;
    }

    public ServiceOptionType(
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

