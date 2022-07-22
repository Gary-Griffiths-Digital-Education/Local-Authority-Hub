namespace WebUI.Models.DtoEntities;

public class ClassificationDto 
{
    public ClassificationDto()
    {
        Name = string.Empty;
    }
    public ClassificationDto(
        string name,
        string? description
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }
}
