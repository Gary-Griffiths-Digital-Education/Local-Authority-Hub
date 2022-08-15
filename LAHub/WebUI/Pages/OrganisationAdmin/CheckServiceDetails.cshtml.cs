using Application.Common.Models;
using LAHub.Domain;
using LAHub.Domain.OpenReferralEnities;
using LAHub.Domain.RecordEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Models;
using WebUI.Services.Api;

namespace WebUI.Pages.OrganisationAdmin;

public class CheckServiceDetailsModel : PageModel
{
    public List<string> ServiceDeliverySelection { get; set; } = new List<string>();
    public List<OpenReferralTaxonomyRecord> SelectedTaxonomy { get; set; } = new List<OpenReferralTaxonomyRecord>();
    public OrganisationViewModel OrganisationViewModel { get; set; } = default!;

    [BindProperty]
    public string? StrOrganisationViewModel { get; set; }

    private readonly IOpenReferralOrganisationAdminClientService _openReferralOrganisationAdminClientService;
    public CheckServiceDetailsModel(IOpenReferralOrganisationAdminClientService openReferralOrganisationAdminClientService)
    {
        _openReferralOrganisationAdminClientService = openReferralOrganisationAdminClientService;
    }

    public async Task OnGet(string strOrganisationViewModel)
    {
        StrOrganisationViewModel = strOrganisationViewModel;

        if (StrOrganisationViewModel != null)
        {
            OrganisationViewModel = JsonConvert.DeserializeObject<OrganisationViewModel>(StrOrganisationViewModel) ?? new OrganisationViewModel();
        }

        PaginatedList<OpenReferralTaxonomyRecord> taxonomies = await _openReferralOrganisationAdminClientService.GetTaxonomyList(1, 9999);

        if (taxonomies != null && OrganisationViewModel != null && OrganisationViewModel.TaxonomySelection != null)
        {
            foreach (string taxonomyKey in OrganisationViewModel.TaxonomySelection)
            {
                OpenReferralTaxonomyRecord? taxonomy = taxonomies.Items.FirstOrDefault(x => x.Id == taxonomyKey);
                if (taxonomy != null)
                {
                    SelectedTaxonomy.Add(taxonomy);
                }
            }
        }

        var myEnumDescriptions = from ServiceDelivery n in Enum.GetValues(typeof(ServiceDelivery))
                                 select new { Id = (int)n, Name = Utility.GetEnumDescription(n) };

        Dictionary<int, string> dictServiceDelivery = new();
        foreach (var myEnumDescription in myEnumDescriptions)
        {
            if (myEnumDescription.Id == 0)
                continue;
            dictServiceDelivery[myEnumDescription.Id] = myEnumDescription.Name;
        }

        if (OrganisationViewModel != null && OrganisationViewModel.ServiceDeliverySelection != null)
        {
            foreach (var item in OrganisationViewModel.ServiceDeliverySelection)
            {
                if (int.TryParse(item, out int value))
                {
                    ServiceDeliverySelection.Add(dictServiceDelivery[value]);
                }
            }
        }
    }
}
