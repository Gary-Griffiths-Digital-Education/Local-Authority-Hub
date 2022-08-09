using Application.Common.Models;
using LAHub.Domain.OpenReferralEnities;
using LAHub.Domain.RecordEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Models;
using WebUI.Services.Api;

namespace WebUI.Pages.OrganisationAdmin;

public class TypeOfServiceModel : PageModel
{
    private readonly IOpenReferralOrganisationAdminClientService _openReferralOrganisationAdminClientService;
    
    public List<OpenReferralTaxonomyRecord> OpenReferralTaxonomyRecords { get; private set; } = default!;
    [BindProperty]
    public List<string> TaxonomySelection { get; set; } = default!;

    [BindProperty]
    public string? StrOrganisationViewModel { get; private set; }

    public TypeOfServiceModel(IOpenReferralOrganisationAdminClientService openReferralOrganisationAdminClientService)
    {
        _openReferralOrganisationAdminClientService = openReferralOrganisationAdminClientService;
    }



    public async Task OnGet(string strOrganisationViewModel)
    {
        StrOrganisationViewModel = strOrganisationViewModel;

        PaginatedList<OpenReferralTaxonomyRecord>  taxonomies = await _openReferralOrganisationAdminClientService.GetTaxonomyList();

        if (taxonomies != null)
            OpenReferralTaxonomyRecords = new List<OpenReferralTaxonomyRecord>(taxonomies.Items);
    }

    public IActionResult OnPost()
    {
        if (StrOrganisationViewModel != null)
        {
            var organisationViewModel = JsonConvert.DeserializeObject<OrganisationViewModel>(StrOrganisationViewModel) ?? new OrganisationViewModel();
        }
        

        return RedirectToPage("/OrganisationAdmin/ServiceDeliveryType", new
        {
            strOrganisationViewModel = StrOrganisationViewModel
        });
    }
}