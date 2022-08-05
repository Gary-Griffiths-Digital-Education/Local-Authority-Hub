using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Pages.OrganisationAdmin;

public class ServiceNameModel : PageModel
{
    public string ServiceName { get; set; } = default!;
    public string ServiceDescription { get; set; } = default!;
    public string? StrOrganisationViewModel { get; private set; }
    public void OnGet(string strOrganisationViewModel)
    {
        StrOrganisationViewModel = strOrganisationViewModel;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (StrOrganisationViewModel != null)
        {
            var organisationViewModel = JsonConvert.DeserializeObject<OrganisationViewModel>(StrOrganisationViewModel) ?? new OrganisationViewModel();

            organisationViewModel.ServiceName = ServiceName;
            organisationViewModel.ServiceDescription = ServiceDescription;

            StrOrganisationViewModel = JsonConvert.SerializeObject(organisationViewModel);
        }

        return RedirectToPage("/OrganisationAdmin/TypeOfService", new
        {
            strOrganisationViewModel = StrOrganisationViewModel
        });
    }
}
