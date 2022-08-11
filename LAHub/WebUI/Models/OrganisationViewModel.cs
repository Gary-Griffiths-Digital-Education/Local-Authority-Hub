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
    public List<string>? InPersonSelection { get; set; } = default!;
    public List<string>? WhoForSelection { get; set; } = default!;
    public List<string>? Languages { get; set; } = default!;
    public int? MinAge { get; set; } = default!;
    public int? MaxAge { get; set; } = default!;
    public string? Address_1 { get; set; } = default!;
    public string? City { get; set; } = default!;
    public string? Postal_code { get; set; } = default!;
    public string? Country { get; set; } = default!;
    public string? State_province { get; set; } = default!;

}
