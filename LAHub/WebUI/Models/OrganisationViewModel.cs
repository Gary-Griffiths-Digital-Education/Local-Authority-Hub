namespace WebUI.Models;

public class OrganisationViewModel
{
    
    public Guid Id { get; set; }
    public string? Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Logo { get; set; }
    public string? Uri { get; set; }
    public string? Url { get; set; }

    public string? ServiceName { get; set; }
    public string? ServiceDescription { get; set; }
    public List<string>? TaxonomySelection { get; set; } = default!;
    public List<string>? ServiceDeliverySelection { get; set; } = default!;

}
