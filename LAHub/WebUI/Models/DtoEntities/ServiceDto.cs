namespace WebUI.Models.DtoEntities;

public class ServiceDto
{
    public ServiceDto()
    {
        Name = String.Empty;
    }
    public ServiceDto(
        string name,
        string? description,
        int minimumAge,
        int maximumAge,
        string? costAmount,
        string? costDescription,
        string? openingHours,
        OrganisationDto? organisation,
        ContactDto? contact,
        LocationDto? location
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description ?? string.Empty;
        MinimumAge = minimumAge;
        MaximumAge = maximumAge;
        CostAmount = costAmount;
        CostDescription = costDescription;
        OpeningHours = openingHours;
        Organisation = organisation;
        if(organisation != null)
        {
            OrganisationId = organisation.Id;
        }
        Contact = contact;
        if (contact != null)
        {
            ContactId = contact.Id;
        }
        Location = location;
        if (location != null)
        {
            LocationId = location.Id;
        }
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int MinimumAge { get; set; }
    public int MaximumAge { get; set; }
    public string? CostAmount { get; set; }
    public string? CostDescription { get; set; }
    public string? OpeningHours { get; set; }
    public Guid? OrganisationId { get; set; }
    public virtual OrganisationDto? Organisation { get; set; } = default!;
    public Guid? ContactId { get; set; }
    public virtual ContactDto? Contact { get; set; } = default!;
    public Guid? LocationId { get; set; }
    public virtual LocationDto? Location { get; set; } = default!;
    public ICollection<ServiceClassificationDto> ServiceClassifications { get; set; } = default!;
}
