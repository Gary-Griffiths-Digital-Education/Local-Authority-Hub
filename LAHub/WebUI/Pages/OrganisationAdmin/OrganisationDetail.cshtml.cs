using Application.Commands.ListOrganisationType;
using LAHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Services.Api;

namespace WebUI.Pages.OrganisationAdmin;

public class OrganisationDetailModel : PageModel
{
    private readonly IOrganisationAdminClientService _organisationAdminClientService;

    private List<OrganisationTypeRecord> _organisationTypeRecords = new List<OrganisationTypeRecord>();

    public List<SelectListItem> OrganisationTypeList { get; private set; } = new List<SelectListItem>();

    [BindProperty]
    public string SelectedOrganisationType { get; set; } = default!;


    [BindProperty]
    public Organisation Organisation { get; set; } = default!;
    public OrganisationDetailModel(IOrganisationAdminClientService organisationAdminClientService)
    {
        _organisationAdminClientService = organisationAdminClientService;
    }
    public async Task OnGet(Guid? id, Guid? tenantId, Guid? organisationTypeId)
    {
        if (id != null)
        {
            Organisation = await _organisationAdminClientService.GetOrganisationById(id.Value);
        }   
        else
        {
            var tennant = await GetTenantById(tenantId);
            var organisationType = await GetOrganisationTypeById(organisationTypeId);

            Organisation = new(
                tennant,
                organisationType,
                "New Organisation",
                null,
                null,
                null,
                new Contact(tennant,"New Contact",
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null)
            );
        }

        await PopulateOrganisationTypeList(Organisation?.OrganisationType?.Name);
    }

    public async Task OnPost()
    {
        await PopulateOrganisationTypeList(Organisation?.OrganisationType?.Name);
    }

    private async Task<Tenant> GetTenantById(Guid? tenantId)
    {
        var tenantList = await _organisationAdminClientService.GetTenantList();
        var tenantRecord = tenantList.FirstOrDefault(x => x.Id == tenantId);
        if (tenantRecord == null)
            throw new ArgumentNullException(nameof(tenantRecord));
        return new Tenant(tenantRecord.Name, tenantRecord.Description)
        {
            Id = tenantRecord.Id
        };
    }

    private async Task<OrganisationType> GetOrganisationTypeById(Guid? organisationTypeId)
    {
        OrganisationType organisationType = new("Unknown", "Unknown");
        if (!_organisationTypeRecords.Any())
        {
            _organisationTypeRecords = await _organisationAdminClientService.GetOrganisationTypeList();
        }
        if (_organisationTypeRecords != null)
        {
            if (organisationTypeId != null)
            {
                var selectedOrganisationTypeRecord = _organisationTypeRecords.FirstOrDefault(x => x.Id == organisationTypeId);
                if (selectedOrganisationTypeRecord is not null)
                {
                    organisationType = new(selectedOrganisationTypeRecord.Name, selectedOrganisationTypeRecord.Description)
                    {
                        Id = selectedOrganisationTypeRecord.Id
                    };
                }

            }
            else
            {
                var selectedOrganisationTypeRecord = _organisationTypeRecords.FirstOrDefault();
                if (selectedOrganisationTypeRecord is not null)
                {
                    organisationType = new(selectedOrganisationTypeRecord.Name, selectedOrganisationTypeRecord.Description)
                    {
                        Id = selectedOrganisationTypeRecord.Id
                    };
                }

            }
        }

        return organisationType;
    }

    private async Task PopulateOrganisationTypeList(string? selectedItem)
    {

        if (!_organisationTypeRecords.Any())
        {
            _organisationTypeRecords = await _organisationAdminClientService.GetOrganisationTypeList();
        }
       
        if (_organisationTypeRecords != null)
        {
            OrganisationTypeList = _organisationTypeRecords.Select(orgType => new SelectListItem
            {
                Text = orgType.Name,
                Value = orgType.Id.ToString()
            }).ToList();

        }

        if (!string.IsNullOrEmpty(selectedItem))
        {
            SelectedOrganisationType = selectedItem;
        }
    }
}
