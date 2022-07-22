namespace Application.Models.DtoEntities;

public class ServiceClassificationDto
{
    public ServiceClassificationDto()
    {
    }

    public ServiceClassificationDto(
        Guid serviceId,
        ClassificationDto classification
    )
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId;
        Classification = classification;
        if (classification != null)
        {
            ClassificationId = classification.Id;
        }
    }

    public Guid Id { get; set; }
    public Guid ServiceId { get; set; }

    public Guid ClassificationId { get; set; }

    public ClassificationDto Classification { get; set; } = default!;
}
