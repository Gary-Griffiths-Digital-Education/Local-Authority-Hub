using Application.Models.DtoEntities;

namespace WebUI.Pages.OrganisationAdmin;

public class OrganisationViewModel
{
    public TenantDto Tenant { get; set; } = default!;

    public OrganisationTypeDto OrganisationType { get; set; } = default!;

    public virtual ContactDto? Contact { get; set; } = default!;

    public virtual ICollection<ServiceDto> Services { get; set; } = default!;
}