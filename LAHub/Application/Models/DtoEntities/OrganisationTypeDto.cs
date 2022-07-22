namespace Application.Models.DtoEntities;

public class OrganisationTypeDto
{
    public OrganisationTypeDto() { }

    public OrganisationTypeDto(
        string name,
        string? description
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;
}
