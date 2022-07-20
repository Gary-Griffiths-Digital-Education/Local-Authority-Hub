namespace LAHub.Domain.Entities;

public class Service : BaseAuditableEntity<Guid>
{
    private Service()
    {
        Name = String.Empty;
    }
    public Service(
        string name,
        string? description,
        int minimumAge,
        int maximumAge,
        string? costAmount,
        string? costDescription,
        string? openingHours,
        Organisation? organisation,
        Contact? contact,
        Location? location
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

    public string Name { get; private set; }
    public string? Description { get; private set; }
    public int MinimumAge { get; private set; }
    public int MaximumAge { get; private set; }
    public string? CostAmount { get; private set; }
    public string? CostDescription { get; private set; }
    public string? OpeningHours { get; private set; }
    public Guid? OrganisationId { get; private set; }
    public virtual Organisation? Organisation { get; private set; } = default!;
    public Guid? ContactId { get; private set; }
    public virtual Contact? Contact { get; private set; } = default!;
    public Guid? LocationId { get; private set; }
    public virtual Location? Location { get; private set; } = default!;
    public ICollection<ServiceClassification> ServiceClassifications { get; set; } = default!;
}
