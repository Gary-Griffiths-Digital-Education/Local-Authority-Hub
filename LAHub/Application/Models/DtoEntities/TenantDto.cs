namespace Application.Models.DtoEntities;

public class TenantDto
{
    public TenantDto() { }

    public TenantDto(
            string name,
            string? description
        )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
    }

    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string? Description { get; set; } = default!;
}

